
using NhibarnateNetCore.Models;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NhibarnateNetCore.Map
{
    public class VehicleMap: ClassMapping<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Identity);
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
            });
            Property(x => x.VehicleName);
            Property(x => x.VehiclePlate);



            Table("vehicle");
        }
    }
}
