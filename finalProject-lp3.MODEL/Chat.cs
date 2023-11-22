using System;
using System.Collections.Generic;

namespace finalProject_lp3.MODEL;

public partial class Chat
{
    public int Id { get; set; }

    public int IdUser1 { get; set; }

    public int IdUser2 { get; set; }

    public virtual ICollection<Message> Messages { get; } = new List<Message>();
}
