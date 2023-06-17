using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IHelper<Table>
    {
        IList<Table> AllData();
        Table Find(int id);


        void Add(Table table);
        void Update(int id, Table table);
        void Delete(int id);

    }
    public interface IHelperCustomers<Table>
    {
        IList<Table> AllData();
        Table Find(string id);


        void Add(Table table);
        void Update(string id, Table table);
        void Delete(string id);

    }
}
