//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zayavki
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zayavka
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime? date_of_note { get; set; } // Обновление типа на DateTime?
    }
}
