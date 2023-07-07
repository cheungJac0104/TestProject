using Autofac; 
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using System.Runtime.Loader;
using TestProject.EntityFrameworkCore; 
using TestProject.Infrastructure.Extensions.AutofacManager;

namespace TPT.App
{
    public static class AutofacExt
    {
       
        public static void InitAutofac(ContainerBuilder builder)
        {

            //注册数据库基础操作和工作单元
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            builder.RegisterType(typeof(UnitWork)).As(typeof(IUnitWork));


            //注册app层
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly());

            InitDependency(builder);
            //定时任务 后期加入
            //builder.RegisterModule(new QuartzAutofacFactoryModule());
        }


        /// <summary>
        /// 注入所有继承了IDependency接口
        /// </summary>
        /// <param name="builder"></param>
        private static void InitDependency(ContainerBuilder builder)
        {
            Type baseType = typeof(IDependency);
            var compilationLibrary = DependencyContext.Default
                .CompileLibraries
                .Where(x => !x.Serviceable
                            && x.Type == "project")
                .ToList();
            var count1 = compilationLibrary.Count;
            List<Assembly> assemblyList = new List<Assembly>();

            foreach (var _compilation in compilationLibrary)
            {
                try
                {
                    assemblyList.Add(AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(_compilation.Name)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(_compilation.Name + ex.Message);
                }
            }

            builder.RegisterAssemblyTypes(assemblyList.ToArray())
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsSelf().AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
