namespace Domain
{
    public class ResidentConverted
    {
        [CsvHelper.Configuration.Attributes.Name("First Name")]
        public string FirstName { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Preferred Name")]
        public string PreferredName { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Resident Type of care")]
        public string ResidentType { get; set; }
        [CsvHelper.Configuration.Attributes.Name("Resident Number")]
        public string RoomNum { get; set; }
        public string PatientUniqueIdentifierType { get; set; }
        public string PatientUniqueIdentifier { get; set; }
    }
}
