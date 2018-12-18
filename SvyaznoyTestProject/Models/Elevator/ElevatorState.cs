using System;

namespace SvyaznoyTestProject.Models
{
    [Flags]
    enum ElevatorStatuses: byte
    {
        DoorsOpened = 1 << 0,
        DoorsClosed = 1 << 1,
        Overload = 1 << 2,
        MovingUp = 1 << 3,
        MovingDown = 1 << 4,
        Stopped = 1 << 5,
        Awaiting = DoorsOpened | Stopped
    }
}
