namespace jarowa
{
    public interface IPhoneNumber
    {
        public string Validate(string phoneNumber, string internationalPrefix);
    }
}
