using System.Net;
using Funq;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace TestApp
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("TestApp", typeof(MyServices).Assembly) { }

        public override void Configure(Container container)
        {
            container.Register<IDbConnectionFactory>(
                c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider));

            Plugins.Add(new AutoQueryFeature());

            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                db.CreateTable<TypeWithEnum>();

                db.Insert(new TypeWithEnum { Id = 1, Name = "Value1", SomeEnum = SomeEnum.Value1, NSomeEnum = SomeEnum.Value1, SomeEnumAsInt = SomeEnumAsInt.Value1, NSomeEnumAsInt = SomeEnumAsInt.Value1 });
                db.Insert(new TypeWithEnum { Id = 2, Name = "Value2", SomeEnum = SomeEnum.Value2, NSomeEnum = SomeEnum.Value2, SomeEnumAsInt = SomeEnumAsInt.Value2, NSomeEnumAsInt = SomeEnumAsInt.Value2 });
                db.Insert(new TypeWithEnum { Id = 3, Name = "Value3", SomeEnum = SomeEnum.Value3, NSomeEnum = SomeEnum.Value3, SomeEnumAsInt = SomeEnumAsInt.Value3, NSomeEnumAsInt = SomeEnumAsInt.Value3 });
            }
        }
    }


    [EnumAsInt]
    public enum SomeEnumAsInt
    {
        Value1 = 1,
        Value2 = 2,
        Value3 = 3,
    }

    public enum SomeEnum
    {
        Value1 = 1,
        Value2 = 2,
        Value3 = 3
    }

    public class TypeWithEnum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SomeEnum SomeEnum { get; set; }
        public SomeEnumAsInt SomeEnumAsInt { get; set; }
        public SomeEnum? NSomeEnum { get; set; }
        public SomeEnumAsInt? NSomeEnumAsInt { get; set; }
    }

    [Route("/query-enums")]
    public class QueryTypeWithEnums : QueryDb<TypeWithEnum> {}

    public class MyServices : Service {}
}