using System;

namespace TaxManager.Domain.Entities
{
    [Flags]
    public enum ItemType
    {
        //This should be fined in DB and fetched
        Book = 1,
        Food = 2,
        ImportedChocolate = 4,
        Medical = 8,
        Music = 16,
        Perfume = 32
    }
}
