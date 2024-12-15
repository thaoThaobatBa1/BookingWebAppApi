using BookingAppApi.Model.VnPay;

namespace BookingAppApi.VnPayService
{
  public interface IVnPayService
  {
    string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
    PaymentResponseModel PaymentExecute(IQueryCollection collections);
  }
}
