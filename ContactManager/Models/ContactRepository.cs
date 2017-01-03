using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class ContactRepository : IContactRepository
    {
        static IList<Contact> contacts = new List<Contact>
        {
            new Contact {ContactId=1,Name="郭靖",Address="临安府牛家村",NickName="北侠" },
            new Contact {ContactId=2,Name="黄蓉",Address="桃花岛",NickName="蓉儿" },
            new Contact {ContactId=3,Name="杨过",Address="桃花岛",NickName="神雕侠" },
            new Contact {ContactId=4,Name="洪七公",Address="全国",NickName="九指神丐" },
            new Contact {ContactId=5,Name="欧阳锋",Address="西域白驼山",NickName="老毒物" },
            new Contact {ContactId=6,Name="黄药师",Address="桃花岛",NickName="东邪" },
            new Contact {ContactId=7,Name="王重阳",Address="终南山重阳宫",NickName="中神通" },
            new Contact {ContactId=8,Name="段智兴",Address="大理",NickName="一灯大师" },
            new Contact {ContactId=9,Name="丘处机",Address="终南山重阳宫",NickName="长春子" }
        };

        public Contact Add(Contact contact)
        {
            contact.ContactId = contacts.Max(c => c.ContactId) + 1;
            contacts.Add(contact);
            return contact;
        }

        public void Delete(int id) => contacts.Remove(Get(id));

        public IEnumerable<Contact> Get() => contacts;

        public Contact Get(int id) => contacts.FirstOrDefault(c => c.ContactId == id);

        public void Update(Contact contact)
        {
            var c = Get(contact.ContactId);
            c.Name = contact.Name;
            c.Address = contact.Address;
            c.NickName = contact.NickName;
        }
    }
}