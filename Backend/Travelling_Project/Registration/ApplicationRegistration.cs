using System;

namespace Registration
{
    public class ApplicationRegistration
    {
            public string EmailId { get; set; }

            public string PhnNo { get; set; }
            public string CreatePassword { get; set; }

            public string ConfirmPassword { get; set; }

            public string Name { get; set; }
            public string Gender { get; set; }

            public string Age { get; set; }

            public string Nationality { get; set; }
    }

    public class ApplicationLogin
    {
        public string EmailId { get; set; }

        public string Password { get; set; }
    }

    public class BookingClass
    {
        public string Name { get; set; }

        public string PhnNo { get; set; }

        public string FromPlace { get; set; }

        public string ToPlace { get; set; }

        public int NoOfPassengers { get; set; }

        public string DateOfJourney { get; set; }

        public string DateOfDeparture { get; set; }
    }

    public class ResetPasswordClass
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

    public class EditProfileClass
    {
        public string OldEmail { get; set; }

        public string EmailId { get; set; }

        public string PhnNo { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Age { get; set; }

        public string Nationality { get; set; }
    }
}
