using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public interface IContactRepository
    {
        void Update(Contact contact);
        Contact Get(int id);
        IEnumerable<Contact> Get();
        Contact Add(Contact contact);
        void Delete(int id);
    }
}
