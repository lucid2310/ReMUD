void** _display_entry_movement(void** ecx, int32_t a2, void** a3, void** a4) {
    void** v5;
    void** ebx6;
    void** v7;
    void** esi8;
    void** v9;
    void** edi10;
    int32_t edi11;
    void** eax12;
    void** esi13;
    int32_t ebx14;
    void** ecx15;
    void** v16;
    void** v17;

    v5 = ebx6;
    v7 = esi8;
    v9 = edi10;
    edi11 = a2;
    eax12 = _get_room_data(a3, a4, v9, v7, v5);
    esi13 = eax12;
    if (esi13) {
        ebx14 = 0;
        while (1) {
            if (edi11 == ebx14) 
                goto addr_436d27_4;
            if (!*reinterpret_cast<int32_t*>(reinterpret_cast<uint32_t>(esi13 + ebx14 * 4) + 0x338)) 
                goto addr_436d27_4;
            eax12 = reinterpret_cast<void**>(static_cast<uint32_t>(*reinterpret_cast<uint16_t*>(reinterpret_cast<uint32_t>(esi13 + ebx14 * 2) + 0x360)));
            if (reinterpret_cast<unsigned char>(eax12) > reinterpret_cast<unsigned char>(11)) 
                goto addr_436d27_4;
            *reinterpret_cast<signed char*>(&eax12) = *reinterpret_cast<signed char*>(reinterpret_cast<unsigned char>(eax12) + reinterpret_cast<uint32_t>(fun_436c9e));
            switch (eax12) {
                addr_436d27_4:
            case 0:
                ++ebx14;
                if (ebx14 < 10) 
                    break; else 
                    goto addr_436d31_8;
            case 1:
                fun_478c28(0x483dd8, v9, v7, v5, 0x483dd8, v9, v7, v5);
                ecx15 = reinterpret_cast<void**>(0x483dd8);
                if (*reinterpret_cast<int32_t*>(ebx14 * 4 + 0x47fe94) != 8) {
                    if (*reinterpret_cast<int32_t*>(ebx14 * 4 + 0x47fe94) != 9) {
                        v16 = *reinterpret_cast<void***>(*reinterpret_cast<int32_t*>(ebx14 * 4 + 0x47fe94) * 4 + 0x47febc);
                        fun_478c28("You hear movement to the %s.\r", v16, v9, v7, "You hear movement to the %s.\r", v16, v9, v7);
                    } else {
                        fun_478c28("You hear movement below you!\r", v9, v7, v5, "You hear movement below you!\r", v9, v7, v5);
                        ecx15 = reinterpret_cast<void**>("You hear movement below you!\r");
                    }
                } else {
                    fun_478c28("You hear movement above you!\r", v9, v7, v5, "You hear movement above you!\r", v9, v7, v5);
                    ecx15 = reinterpret_cast<void**>("You hear movement above you!\r");
                }
                v17 = *reinterpret_cast<void***>(reinterpret_cast<uint32_t>(esi13 + ebx14 * 4) + 0x338);
                eax12 = _tell_room(ecx15, a4, v17, 0xff, 0xff, 0, 1, 1, -1, v9, v7, v5);
                goto addr_436d27_4;
            }
        }
    }
    addr_436d31_8:
    return eax12;
}