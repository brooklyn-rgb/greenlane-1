using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace greenlane.Pages
{
    public class TourBookingModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please select a date")]
        public DateTime TourDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Please select a time")]
        public string TourTime { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Please select number of attendees")]
        public string NumberOfAttendees { get; set; } = "2";

        [BindProperty]
        public string? CurrentGrade { get; set; }

        [BindProperty]
        public string? AdditionalNotes { get; set; }

        [BindProperty]
        public string? AreasOfInterest { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostBookTourAsync()
        {
            try
            {
                Console.WriteLine("DEBUG: Starting OnPostBookTourAsync");

                // Read the JSON body
                using var reader = new StreamReader(Request.Body);
                var body = await reader.ReadToEndAsync();

                Console.WriteLine($"DEBUG: Raw body received: {body}");

                if (string.IsNullOrEmpty(body))
                {
                    Console.WriteLine("DEBUG: Empty body received");
                    return new JsonResult(new { success = false, error = "No data received" });
                }

                // Parse the JSON
                var jsonData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(body);

                // Extract values
                if (jsonData != null)
                {
                    FullName = jsonData.ContainsKey("FullName") ? jsonData["FullName"].GetString() ?? "" : "";
                    Email = jsonData.ContainsKey("Email") ? jsonData["Email"].GetString() ?? "" : "";
                    PhoneNumber = jsonData.ContainsKey("PhoneNumber") ? jsonData["PhoneNumber"].GetString() ?? "" : "";
                    NumberOfAttendees = jsonData.ContainsKey("NumberOfAttendees") ? jsonData["NumberOfAttendees"].GetString() ?? "2" : "2";
                    CurrentGrade = jsonData.ContainsKey("CurrentGrade") ? jsonData["CurrentGrade"].GetString() : "";
                    AdditionalNotes = jsonData.ContainsKey("AdditionalNotes") ? jsonData["AdditionalNotes"].GetString() : "";
                    AreasOfInterest = jsonData.ContainsKey("AreasOfInterest") ? jsonData["AreasOfInterest"].GetString() : "";

                    // FIXED: Proper date parsing
                    if (jsonData.ContainsKey("TourDate"))
                    {
                        var dateElement = jsonData["TourDate"];
                        if (dateElement.ValueKind != JsonValueKind.Null && !string.IsNullOrEmpty(dateElement.GetString()))
                        {
                            var dateString = dateElement.GetString();
                            Console.WriteLine($"DEBUG: Date string received: {dateString}");

                            if (DateTime.TryParse(dateString, out var parsedDate))
                            {
                                TourDate = parsedDate;
                                Console.WriteLine($"DEBUG: Date successfully parsed: {TourDate}");
                            }
                            else
                            {
                                Console.WriteLine($"DEBUG: Failed to parse date: {dateString}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("DEBUG: TourDate is null or empty");
                        }
                    }

                    TourTime = jsonData.ContainsKey("TourTime") ? jsonData["TourTime"].GetString() ?? "" : "";
                }

                // Debug logging for validation
                Console.WriteLine($"DEBUG VALIDATION: FullName='{FullName}', Email='{Email}', Phone='{PhoneNumber}', Date={TourDate}, Time='{TourTime}'");

                // Validate required fields
                if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Email) ||
                    string.IsNullOrEmpty(PhoneNumber) || TourDate == default ||
                    string.IsNullOrEmpty(TourTime))
                {
                    Console.WriteLine($"DEBUG: Validation failed - " +
                        $"FullName empty: {string.IsNullOrEmpty(FullName)}, " +
                        $"Email empty: {string.IsNullOrEmpty(Email)}, " +
                        $"Phone empty: {string.IsNullOrEmpty(PhoneNumber)}, " +
                        $"Date default: {TourDate == default}, " +
                        $"Time empty: {string.IsNullOrEmpty(TourTime)}");

                    return new JsonResult(new
                    {
                        success = false,
                        error = "Please fill in all required fields"
                    });
                }

                // Validate email format
                try
                {
                    var emailAddress = new System.Net.Mail.MailAddress(Email);
                }
                catch
                {
                    Console.WriteLine($"DEBUG: Invalid email format: {Email}");
                    return new JsonResult(new
                    {
                        success = false,
                        error = "Invalid email address format"
                    });
                }

                // Generate booking reference
                var bookingRef = GenerateBookingReference();
                Console.WriteLine($"DEBUG: Generated booking ref: {bookingRef}");

                // Parse AreasOfInterest if present
                List<string> areasList = new List<string>();
                if (!string.IsNullOrEmpty(AreasOfInterest))
                {
                    try
                    {
                        areasList = JsonSerializer.Deserialize<List<string>>(AreasOfInterest) ?? new List<string>();
                    }
                    catch
                    {
                        areasList = new List<string>();
                    }
                }

                // Create booking object
                var booking = new
                {
                    BookingReference = bookingRef,
                    TourDate = TourDate.ToString("dddd, MMMM dd, yyyy"),
                    TourTime = FormatTime(TourTime),
                    FullName,
                    PhoneNumber,
                    Email,
                    NumberOfAttendees,
                    CurrentGrade = CurrentGrade ?? "Not specified",
                    AdditionalNotes = AdditionalNotes ?? "",
                    AreasOfInterest = string.Join(", ", areasList),
                    BookingDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };

                // Send confirmation email
                var emailSent = await SendConfirmationEmail(booking);

                // Log booking
                Console.WriteLine($"Booking created: {bookingRef} for {FullName}");

                // Save to JSON file (temporary solution)
                await SaveBookingToFile(booking);

                return new JsonResult(new
                {
                    success = true,
                    bookingReference = bookingRef,
                    tourDate = $"{TourDate:MMMM dd, yyyy} at {FormatTime(TourTime)}",
                    emailSent = emailSent
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR in OnPostBookTourAsync: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return new JsonResult(new
                {
                    success = false,
                    error = "An error occurred while processing your booking. Please try again."
                });
            }
        }

        private string GenerateBookingReference()
        {
            var year = DateTime.Now.Year;
            var random = new Random();
            var number = random.Next(100000, 999999);
            return $"GL-{year}-{number}";
        }

        private string FormatTime(string time)
        {
            if (DateTime.TryParseExact(time, "HH:mm", null, System.Globalization.DateTimeStyles.None, out var timeValue))
            {
                return timeValue.ToString("h:mm tt");
            }
            return time;
        }

        private async Task SaveBookingToFile(dynamic booking)
        {
            try
            {
                var bookingsPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "Bookings");
                Directory.CreateDirectory(bookingsPath);

                var fileName = $"Booking_{booking.BookingReference}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                var filePath = Path.Combine(bookingsPath, fileName);

                var json = JsonSerializer.Serialize(booking, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                await System.IO.File.WriteAllTextAsync(filePath, json);
                Console.WriteLine($"Booking saved to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving booking to file: {ex.Message}");
            }
        }

        private async Task<bool> SendConfirmationEmail(dynamic booking)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var smtpServer = configuration["EmailSettings:SmtpServer"] ?? "smtp.sendgrid.net";
                var smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"] ?? "587");
                var fromEmail = configuration["EmailSettings:SenderEmail"] ?? "noreply@greenlane.co.za";
                var fromName = configuration["EmailSettings:SenderName"] ?? "Greenlane College Admissions";
                var smtpUsername = configuration["EmailSettings:SmtpUsername"] ?? "apikey";

                // Get API key from environment variable
                var smtpPassword = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

                if (string.IsNullOrEmpty(smtpPassword))
                {
                    Console.WriteLine("WARNING: SendGrid API Key not found in environment variables.");
                    return true; // Return true so booking still works without email
                }

                using var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                    EnableSsl = true,
                };

                var emailBody = $@"
Dear {booking.FullName},

Thank you for booking a tour of Greenlane College!

BOOKING CONFIRMATION
====================
Booking Reference: {booking.BookingReference}
Tour Date: {booking.TourDate}
Tour Time: {booking.TourTime}
Number of Attendees: {booking.NumberOfAttendees}

IMPORTANT INFORMATION:
----------------------
• Please arrive 15 minutes before your scheduled tour time
• Check in at the main reception desk
• Bring a valid photo ID
• Parking is available in the visitor parking lot

If you need to reschedule or cancel, please contact our admissions office.

We look forward to welcoming you to Greenlane College!

Best regards,
Greenlane College Admissions Office
";

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail, fromName),
                    Subject = $"Greenlane College Tour Booking - {booking.BookingReference}",
                    Body = emailBody,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(booking.Email);
                await smtpClient.SendMailAsync(mailMessage);

                Console.WriteLine($"Confirmation email sent to: {booking.Email}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Email failed: {ex.Message}");
                return false;
            }
        }
    }
}