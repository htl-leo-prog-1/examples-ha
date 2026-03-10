using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultingHours;

public class RoomStatistic
{
    private string _room="";
    private int _count;

    public void SetRoom(string room)
    {
        _room = room;
    }

    public string GetRoom()
    {
        return _room;
    }

    public void SetCount(int count)
    {
        _count = count;
    }

    public int GetCount()
    {
        return _count;
    }
}