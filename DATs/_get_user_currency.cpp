void** _get_user_currency(void** ecx, void** a2, void** a3)
 {
    void** ebp4;
    void** eax5;
    void** v6;
    void** v7;
    void** v8;
    void** v9;
    void** v10;
    void** eax11;

    eax5 = _get_player(ecx, a2, ebp4, __return_address(), a2);

    if (!eax5)
    {
        return 0;
    } 
    else
    {
        v6 = *reinterpret_cast<void***>(eax5 + 0x620);
        v7 = *reinterpret_cast<void***>(eax5 + 0x61c);
        v8 = *reinterpret_cast<void***>(eax5 + 0x618);
        v9 = *reinterpret_cast<void***>(eax5 + 0x614);
        v10 = *reinterpret_cast<void***>(eax5 + 0x610);
        eax11 = _convert_currency(a2, v10, v9, v8, v7, v6);
        return eax11;
    }
}