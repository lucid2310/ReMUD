void** _get_light_level(void** ecx, void** a2, void** a3, void** a4)
 {
    void** v5;
    void** ebx6;
    void** v7;
    void** esi8;
    void** v9;
    void** edi10;
    void** edi11;
    void** ebx12;
    void** eax13;
    void** v14;
    void** ecx15;
    void** v16;
    void** eax17;
    void* esi18;
    void** eax19;
    void* esi20;
    void* v21;
    void* v22;
    void** ebx23;
    void** ecx24;
    void** eax25;
    void** eax26;
    void** eax27;
    void** esi28;
    void** eax29;
    void** ecx30;
    void** edx31;
    void** eax32;
    void** ecx33;
    void** edx34;
    void** eax35;

    v5 = ebx6;
    v7 = esi8;
    v9 = edi10;
    edi11 = a4;
    ebx12 = a3;
    
    if (a2 != 0xffffffff)
    {
        eax13 = _get_player(ecx, a2, v9, v7, v5);
        ebx12 = eax13;
    }

    if (ebx12) 
    {
        MapNumber = *reinterpret_cast<void***>(player.MapNumber);
        RoomNumber = *reinterpret_cast<void***>(player.RoomNumber);


        Room = _get_room_data(player.MapNumber, player.RoomNumber, v9, v7, v5);

        if (Room)
        {
            esi18 = Room.LightLevel;

            eax19 = _get_user_ability_value(player, AbilityTypes.Illuminate);

            esi20 = Room.LightLevel + player.LightLevel;

            v21 = v22;

            ebx23 = 0;

            while (ecx24 = _nterms, (ebx23) < ecx24)
            {
                eax25 = fun_46b93c(ecx24, ebx23);

                if (*reinterpret_cast<signed char*>(&eax25) && 
                    ((eax26 = _get_player(ebx23, ebx23, v9, v7, v5), !!eax26) &&
                     (*reinterpret_cast<void***>(player.RoomNumber) == MapNumber &&
                      *reinterpret_cast<void***>(player.MapNumber) == RoomNumber)))
                {
                    // 0xCC and 0x6BC are unknown in the player structure currently.
                    esi20 = reinterpret_cast<void*>(reinterpret_cast<uint32_t>(esi20) +
                     (reinterpret_cast<int16_t>(*reinterpret_cast<void***>(eax26 + 0xcc)) +
                      reinterpret_cast<uint32_t>(static_cast<int32_t>(*reinterpret_cast<int16_t*>(eax26 + 0x6bc)))));
                }

                ++ebx23;
            }

            if (esi20 >= 0x384)
            {
                esi20 = 0x384;
            }
        }
        else 
        {
            eax27 = reinterpret_cast<void**>(0);
            goto addr_41f1e4_13;
        }
    } 
    else
    {
        eax27 = reinterpret_cast<void**>(0);
        goto addr_41f1e4_13;
    }

    esi28 = reinterpret_cast<void**>(reinterpret_cast<uint32_t>(esi20) + reinterpret_cast<uint32_t>(v21));

    // - 199 - pitch black - you cant see anything.
    if (reinterpret_cast<signed char>(esi28) >= reinterpret_cast<signed char>(0xffffff38))
    {
        // - 149 - The room is very dark - you cant see anything.
        if (reinterpret_cast<signed char>(esi28) >= reinterpret_cast<signed char>(0xffffff6a))
         {
            // - 99 - The room is barely visible.
            if (reinterpret_cast<signed char>(esi28) >= reinterpret_cast<signed char>(0xffffff9c))
             {
                // + 0 - The room is dimly lit.
                if (reinterpret_cast<signed char>(esi28) >= reinterpret_cast<signed char>(0))
                 {
                    // + 200
                    if (reinterpret_cast<signed char>(esi28) >= reinterpret_cast<signed char>(0xc8))
                     {
                        // + 900
                        if (reinterpret_cast<signed char>(esi28) >= reinterpret_cast<signed char>(0x384))
                        {
                            eax29 = image_base_;
                            *reinterpret_cast<void***>(edi11) = eax29;
                        } 
                        else
                        {
                            ecx30 = image_base_;
                            *reinterpret_cast<void***>(edi11) = ecx30;
                        }
                    } 
                    else
                    {
                        edx31 = image_base_;
                        *reinterpret_cast<void***>(edi11) = edx31;
                    }
                } 
                else
                {
                    eax32 = image_base_;
                    *reinterpret_cast<void***>(edi11) = eax32;
                }
            } 
            else
            {
                ecx33 = image_base_;
                *reinterpret_cast<void***>(edi11) = ecx33;
            }
        } 
        else
        {
            edx34 = image_base_;
            *reinterpret_cast<void***>(edi11) = edx34;
        }
    } 
    else 
    {
        eax35 = image_base_;
        *reinterpret_cast<void***>(edi11) = eax35;
    }
    
    eax27 = esi28;
    addr_41f1e4_13:
    return eax27;
}