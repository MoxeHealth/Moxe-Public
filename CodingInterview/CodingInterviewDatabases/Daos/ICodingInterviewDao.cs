namespace CodingInterview.Databases
{
    public interface ICodingInterviewDao
    {
        Customer GetCustomer(int id);
        Invoice GetInvoice(int id);
        Item GetItem(int id);
    }
}