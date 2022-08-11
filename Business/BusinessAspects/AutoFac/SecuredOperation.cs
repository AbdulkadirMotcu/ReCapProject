using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;


namespace Business.BusinessAspects.AutoFac
{
    //JWT için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;//rolleri ver
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//Belirtilen karaktere göre ayırıp arraye atılır
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();//kullanıcını claimleri bul 
            foreach (var role in _roles)//rollerini gez
            {
                if (roleClaims.Contains(role))//rol varsa true
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);// yoksa hata mesajı ver
        }
    }
}
