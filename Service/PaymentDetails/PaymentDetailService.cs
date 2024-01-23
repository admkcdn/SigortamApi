using DAL;
using Data.Model;
using Utilities.Results;

namespace Service.PaymentDetails
{
    public interface IPaymentDetailService
    {
        Task<IDataResult<PaymentDetail>> Create(PaymentDetail paymentDetail);
        Task<IDataResult<PaymentDetail>> Update(PaymentDetail paymentDetail);
        Task<IDataResult<PaymentDetail>> Delete(int id);
        Task<IDataResult<PaymentDetail>> Get(int id);
        Task<IDataResult<List<PaymentDetail>>> GetAll();
        Task<IDataResult<List<PaymentDetail>>> GetByCompanyId(int companyId);
    }
    public class PaymentDetailService : IPaymentDetailService
    {
        private readonly IPaymentDetailDal _paymentDetailDal;

        public PaymentDetailService(IPaymentDetailDal paymentDetailDal)
        {
            _paymentDetailDal = paymentDetailDal;
        }

        public async Task<IDataResult<PaymentDetail>> Create(PaymentDetail paymentDetail)
        {
            try
            {
                var res = await _paymentDetailDal.Create(paymentDetail);
                if (res != null)
                {
                    return new SuccessDataResult<PaymentDetail>(res);
                }
                return new ErrorDataResult<PaymentDetail>("Payment detail create failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PaymentDetail>(ex.Message);
            }
        }

        public async Task<IDataResult<PaymentDetail>> Delete(int id)
        {
            try
            {
                var res = await _paymentDetailDal.Delete(id);
                if (res != null)
                {
                    return new SuccessDataResult<PaymentDetail>(res);
                }
                return new ErrorDataResult<PaymentDetail>("Payment detail delete failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PaymentDetail>(ex.Message);
            }
        }

        public async Task<IDataResult<PaymentDetail>> Get(int id)
        {
            try
            {
                var res = await _paymentDetailDal.Get(id);
                if (res != null)
                {
                    return new SuccessDataResult<PaymentDetail>(res);
                }
                return new SuccessDataResult<PaymentDetail>(res, "Payment detail not found.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PaymentDetail>(ex.Message);
            }
        }

        public async Task<IDataResult<List<PaymentDetail>>> GetAll()
        {
            try
            {
                var res = await _paymentDetailDal.GetAll();
                return new SuccessDataResult<List<PaymentDetail>>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PaymentDetail>>(ex.Message);
            }
        }

        public async Task<IDataResult<List<PaymentDetail>>> GetByCompanyId(int companyId)
        {
            try
            {
                var res = await _paymentDetailDal.GetByCompanyId(companyId);
                return new SuccessDataResult<List<PaymentDetail>>(res);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<PaymentDetail>>(ex.Message);
            }
        }

        public async Task<IDataResult<PaymentDetail>> Update(PaymentDetail paymentDetail)
        {
            try
            {
                var res = await _paymentDetailDal.Update(paymentDetail);
                if (res != null)
                {
                    return new SuccessDataResult<PaymentDetail>(res);
                }
                return new ErrorDataResult<PaymentDetail>("Payment detail update failed.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<PaymentDetail>(ex.Message);
            }
        }
    }
}
