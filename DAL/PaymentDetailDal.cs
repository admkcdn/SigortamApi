using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IPaymentDetailDal
    {
        Task<PaymentDetail> Create(PaymentDetail paymentDetail);
        Task<PaymentDetail> Update(PaymentDetail paymentDetail);
        Task<PaymentDetail> Delete(int id);
        Task<PaymentDetail> Get(int id);
        Task<List<PaymentDetail>> GetAll();
        Task<List<PaymentDetail>> GetByCompanyId(int companyId);
    }
    public class PaymentDetailDal : IPaymentDetailDal
    {
        private readonly ApplicationContext _applicationContext;

        public PaymentDetailDal(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<PaymentDetail> Create(PaymentDetail paymentDetail)
        {
            try
            {
                var reuslt = await _applicationContext.AddAsync(paymentDetail);
                var res = await _applicationContext.SaveChangesAsync();
                if (res > 0)
                    return paymentDetail;
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PaymentDetail> Delete(int id)
        {
            try
            {
                var paymentDetail = await _applicationContext.PaymentDetails.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (paymentDetail != null)
                {
                    _applicationContext.PaymentDetails.Remove(paymentDetail);
                    var result = await _applicationContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return paymentDetail;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PaymentDetail> Get(int id)
        {
            try
            {
                var paymentDetail = await _applicationContext.PaymentDetails.Where(x => x.ID == id).FirstAsync();
                return paymentDetail;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task<List<PaymentDetail>> GetAll()
        {
            try
            {
                return await _applicationContext.PaymentDetails.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<PaymentDetail>> GetByCompanyId(int companyId)
        {
            try
            {
                var res = await _applicationContext.PaymentDetails.Where(x => x.CompanyID == companyId).ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PaymentDetail> Update(PaymentDetail paymentDetail)
        {
            try
            {
                var res = _applicationContext.PaymentDetails.Update(paymentDetail);
                var result = await _applicationContext.SaveChangesAsync();
                if (result > 0)
                {
                    return paymentDetail;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
