void** _can_see(void** ecx, void** a2, void** room, void** a4, void** a5) {
    void** eax6;
    void** v7;
    void** edi8;
    void** esi9;
    void** v10;
    void** ebx11;

    room = a3;

    if (!a4 || (!a5 || !room)) 
    {
        *reinterpret_cast<signed char*>(&room) = 1;
    } 
    else 
    {
        if (!(*reinterpret_cast<unsigned char*>(room + 0x6f5) & 16))
        {
            eax6 = _get_light_level(ecx, a2, 0, a5);

            *reinterpret_cast<void***>(a4) = eax6;

            if (reinterpret_cast<signed char>(*reinterpret_cast<void***>(a4)) >= reinterpret_cast<signed char>(0xffffff6a))
            {
                if (reinterpret_cast<signed char>(*reinterpret_cast<void***>(a4)) <= reinterpret_cast<signed char>(0x384))
                {
                    *reinterpret_cast<signed char*>(&eax6) = 1;
                } 
                else 
                {
                    v7 = *reinterpret_cast<void***>(a5);
                    fun_478c28("%s\r", v7, edi8, esi9);
                    _tell_user(ecx, a2);
                    eax6 = reinterpret_cast<void**>(0);
                }
            } 
            else
            {
                v10 = *reinterpret_cast<void***>(a5);
                fun_478c28("The room is %s - you can't see anything\r", v10, edi8, esi9);
                _tell_user(ecx, a2);
                eax6 = reinterpret_cast<void**>(0);
            }
        } 
        else
        {
            fun_478c28("You are blind.\r", edi8, esi9, ebx11);
            _tell_user("You are blind.\r", a2, a2);
            eax6 = reinterpret_cast<void**>(0);
        }
    }

    return eax6;
}