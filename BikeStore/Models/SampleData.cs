using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BikeStore.Models
{
    public class SampleData : DropCreateDatabaseAlways<BikeStoreEntities>
    {
        protected override void Seed(BikeStoreEntities context)
        {
            var types = new List<Type>
            {   new Type {TypeName = "Mountain", TypeDesc = "Mountain" }, 
                new Type {TypeName = "Street", TypeDesc = "Street" },
                new Type { TypeName = "Hybrid", TypeDesc = "Hybrid" },
                new Type { TypeName = "Road", TypeDesc = "Road" },
                new Type { TypeName = "Children", TypeDesc = "Children" },
            };
             types.ForEach(a => context.Types.Add(a));

            var frames = new List<Frame>
            { new Frame { FrameName = "S", FrameDesc = "Small" },
              new Frame { FrameName = "M", FrameDesc = "Medium" },
              new Frame { FrameName = "L", FrameDesc = "Large" },
              new Frame { FrameName = "XLar", FrameDesc = "Extra Large" },
            };
            frames.ForEach(f => context.Frames.Add(f));

            var stores = new List<Store>
            { new Store {StoreName = "Cincinnati Store", Address = "Cincinnati", Telephone="5138866696",City="Cincinnati"},
              new Store {StoreName = "Newyork Store", Address = "Newyork", Telephone="5138866697",City="Newyork"},
              new Store { StoreName = "Chicago Store", Address = "Chicago", Telephone = "5138866671",City="Chicago" },
            };
            stores.ForEach(s => context.Stores.Add(s));

            var prodstatuss = new List<ProdStatus>
            { new ProdStatus { ProdStatusName = "InStock" },
              new ProdStatus { ProdStatusName = "Pending" },
              new ProdStatus { ProdStatusName = "Reserve" },
            };
            prodstatuss.ForEach(p => context.ProdStatuss.Add(p));

            var orderstatuss = new List<OrderStatus>
             {new OrderStatus { OrderStatusName = "Online" },
              new OrderStatus { OrderStatusName = "InStore" },
             };
            orderstatuss.ForEach(or => context.OrderStatuss.Add(or));

            var users = new List<User>
             {new User { EmailId = "tom",Password="tom123",ConfirmPassword="tom123" },
              new User { EmailId = "kim",Password="kim123",ConfirmPassword="kim123" },
              new User { EmailId = "lime",Password="lime123",ConfirmPassword="lime123" },
             };
            users.ForEach(us => context.Users.Add(us));

            var paymodes = new List<PayMode>
            { new PayMode{PayMethod = "Cash"},
              new PayMode{PayMethod = "Card"},
              new PayMode { PayMethod = "Check" },
            };
            paymodes.ForEach(p => context.PayModes.Add(p));


            var orderstages = new List<OrderStage>
            {  new OrderStage { OrderStageName = "Pending" },
               new OrderStage { OrderStageName = "Confirm" },
            };
            orderstages.ForEach(o => context.OrderStages.Add(o));

            var employeetypes = new List<EmployeeType>
            {new EmployeeType { EmployeeTypeName = "Manager" },
             new EmployeeType { EmployeeTypeName = "Employee" },
            };
            employeetypes.ForEach(e => context.EmployeeTypes.Add(e));

            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "S"), Type = types.Single(t => t.TypeName=="Road"), ModelName="Hero", BrandName="BrandH",Store = stores.Single(s=>s.StoreName=="Newyork Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p=>p.ProdStatusName=="InStock")});
            //context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "M"), Type = types.Single(t => t.TypeName == "Mountain"), ModelName = "Hero", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "NewYork Store"), Desc = "DescriptionProduct", UnitPrice = 300, SellingPrice = 300, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock") });
            //context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "L"), Type = types.Single(t => t.TypeName == "Street"), ModelName = "Suzuki", BrandName = "BrandS", Store = stores.Single(s => s.StoreName == "NewYork Store"), Desc = "DescriptionProduct", UnitPrice = 200, SellingPrice = 200, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock") });
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "L"), Type = types.Single(t => t.TypeName == "Street"), ModelName = "Atlas", BrandName = "BrandA", Store = stores.Single(s => s.StoreName == "Cincinnati Store"), Desc = "DescriptionProduct", UnitPrice = 500, SellingPrice = 500, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock") });
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "L"), Type = types.Single(t => t.TypeName == "Mountain"), ModelName = "Suzuki", BrandName = "BrandA", Store = stores.Single(s => s.StoreName == "Cincinnati Store"), Desc = "DescriptionProduct", UnitPrice = 500, SellingPrice = 500, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock") });
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "M"), Type = types.Single(t => t.TypeName == "Road"), ModelName = "Hero", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "Chicago Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock")});
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "S"), Type = types.Single(t => t.TypeName == "Hybrid"), ModelName = "American Star Bicycle", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "Cincinnati Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock")});
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "M"), Type = types.Single(t => t.TypeName == "Children"), ModelName = "Hero", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "Chicago Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock")});
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "L"), Type = types.Single(t => t.TypeName == "Mountain"), ModelName = "Hero", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "Newyork Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock") });
            //context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "XL"), Type = types.Single(t => t.TypeName == "Mountain"), ModelName = "Bontrager", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "Chicago Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock")});
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "M"), Type = types.Single(t => t.TypeName == "Road"), ModelName = "Bontrager", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "Chicago Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock")});
            context.Inventories.Add(new Inventory { Frame = frames.Single(f => f.FrameName == "S"), Type = types.Single(t => t.TypeName == "Hybrid"), ModelName = "Burley Design", BrandName = "BrandH", Store = stores.Single(s => s.StoreName == "Newyork Store"), Desc = "DescriptionProduct", UnitPrice = 1000, SellingPrice = 100, ProdStatus = prodstatuss.Single(p => p.ProdStatusName == "InStock")});

            context.Employees.Add(new Employee { EmployeeName = "Arjun", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Manager"), EmpPassword = "arjun123", SSN = "987456321", Store = stores.Single(s => s.StoreName == "Cincinnati Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Phani", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "phani123", SSN = "987456322", Store = stores.Single(s => s.StoreName == "Newyork Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Karthik", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "karthik123", SSN = "987456323", Store = stores.Single(s => s.StoreName == "Newyork Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Kiran", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "kiran123", SSN = "987456324", Store = stores.Single(s => s.StoreName == "Chicago Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Ankur", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "ankur123", SSN = "987456325", Store = stores.Single(s => s.StoreName == "Cincinnati Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Kaushal", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "kaushal123", SSN = "987456326", Store = stores.Single(s => s.StoreName == "Chicago Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Nanda", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "nanda123", SSN = "987456327", Store = stores.Single(s => s.StoreName == "Cincinnati Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Vicky", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "vicky123", SSN = "987456328", Store = stores.Single(s => s.StoreName == "Newyork Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Ajinkya", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "ajinkya123", SSN = "987456329", Store = stores.Single(s => s.StoreName == "Chicago Store"), InvSold = 0 });
            context.Employees.Add(new Employee { EmployeeName = "Anish", EmployeeDOB = DateTime.Now, EmployeeType = employeetypes.Single(e => e.EmployeeTypeName == "Employee"), EmpPassword = "anish123", SSN = "987456330", Store = stores.Single(s => s.StoreName == "Cincinnati Store"), InvSold = 0 });
            context.SaveChanges();


            //var inventories = new List<Inventory>
            //{
            //    new Inventory{Frame=frames.Single(f=>f.FrameName=="S"),Type=types.Single(t=>t.TypeName=="Road"),ModelName="Hero",BrandName="BrandH",Store=stores.Single(s=>s.StoreName=="California Store"),Desc="DescriptionProduct",UnitPrice=1000,SellingPrice=100,ProdStatus=prodstatuss.Single(p=>p.ProdStatusName=="InStock")},
            //    new Inventory{Frame=frames.Single(f=>f.FrameName=="M"),Type=types.Single(t=>t.TypeName=="Mountain"),ModelName="Hero",BrandName="BrandH",Store=stores.Single(s=>s.StoreName=="NewYork Store"),Desc="DescriptionProduct",UnitPrice=300,SellingPrice=300,ProdStatus=prodstatuss.Single(p=>p.ProdStatusName=="InStock")},
            //    new Inventory{Frame=frames.Single(f=>f.FrameName=="L"),Type=types.Single(t=>t.TypeName=="Street"),ModelName="Suzuki",BrandName="BrandS",Store=stores.Single(s=>s.StoreName=="NewYork Store"),Desc="DescriptionProduct",UnitPrice=200,SellingPrice=200,ProdStatus=prodstatuss.Single(p=>p.ProdStatusName=="InStock")},
            //    new Inventory{Frame=frames.Single(f=>f.FrameName=="L"),Type=types.Single(t=>t.TypeName=="Street"),ModelName="Atlas",BrandName="BrandA",Store=stores.Single(s=>s.StoreName=="Cincinnati Store"),Desc="DescriptionProduct",UnitPrice=500,SellingPrice=500,ProdStatus=prodstatuss.Single(p=>p.ProdStatusName=="InStock")},

            //};
            //inventories.ForEach(i => context.Inventories.Add(i));
            //var frames = new List<Frame>
            //{
            //    new Frame { FrameName = "M",FrameDesc="Medium"},
            //    new Frame { FrameName = "L",FrameDesc="Large"}
            //};

    

            //var stores = new List<Store> 
            //{ 
            //    new Store{StoreName="NewYork Store",City="NYCity",Address="NewYAdd",Telephone="8989898898"},
            //    new Store{StoreName="Cincinnati Store",City="Cincinnati",Address="Cincinnati",Telephone="8989898898"}
            //};

            //new List<Inventory>
            //{
            //    new Inventory{Frame=frames.Single(f=>f.FrameName=="M"),Type=types.Single(t=>t.TypeName=="Mountain"),ModelName="ABC",BrandName="BrandN",Store=stores.Single(s=>s.StoreName=="NewYork Store"),Desc="DescriptionProduct",UnitPrice=300,SellingPrice=400},
            //    new Inventory{Frame=frames.Single(f=>f.FrameName=="L"),Type=types.Single(t=>t.TypeName=="Street"),ModelName="XYZ",BrandName="BrandS",Store=stores.Single(s=>s.StoreName=="NewYork Store"),Desc="DescriptionProduct",UnitPrice=200,SellingPrice=450},
            //    new Inventory{Frame=frames.Single(f=>f.FrameName=="L"),Type=types.Single(t=>t.TypeName=="Street"),ModelName="XYZ",BrandName="BrandS",Store=stores.Single(s=>s.StoreName=="Cincinnati Store"),Desc="DescriptionProduct",UnitPrice=200,SellingPrice=450}
              
            //}.ForEach(a => context.Inventories.Add(a));

            ////var employeetypes = new List<EmployeeType>
            ////{
            ////    new EmployeeType{EmployeeTypeName="Employee",EmployeeTypeDesc="Employee"},
            ////    new EmployeeType{EmployeeTypeName="Manager",EmployeeTypeDesc="Manager"}
            ////};
            ////new List<Employee>
            ////{
            ////    new Employee{EmployeeName="Rex",EmployeeDOB=DateTime.Now,EmployeeType=employeetypes.Single(e=>e.EmployeeTypeName=="Employee"),InvSold=9,SSN="9595959"},
            ////      new Employee{EmployeeName="Max",EmployeeDOB=DateTime.Now,EmployeeType=employeetypes.Single(e=>e.EmployeeTypeName=="Manager"),InvSold=8,SSN="6666652"}
            ////}.ForEach(a => context.Employees.Add(a));

            //new List<PayMode>
            //{
            //    new PayMode{PayMethod="Card"},
            //    new PayMode{PayMethod="Cash"},
            //    new PayMode{PayMethod="Check"}
            //}.ForEach(a => context.PayModes.Add(a));


      
            
        }

    }
}