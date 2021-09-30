namespace jarowa.Api.Phone
{
    public interface IPhoneNumber
    {
        public string Validate(string phoneNumber, string internationalPrefix);
    }
}
