using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        //string.Join(" , ") birleştirilen iki methodun arasına , koyar
        public override void Intercept(IInvocation invocation)
        {                  //isim eşsizolabilmes, için namespaceteki ismi çağırılır   //Methodun adı : CacheAspect
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();//methodları listeledi
            var key = $"{methodName}({string.Join(" , ", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//burada methodName ile argumanları belirlenen kalıba göre birleştiti //
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);//ramdeki cache değerini döndürür
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);//istenilen değer ramde yok ise ekler ama _duration zamanı kadar ramde kalır
        }

    }
}
