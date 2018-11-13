int32_t _cmd_look(struct s0* a1)
{
    
    

    ebp2 = reinterpret_cast<void*>(reinterpret_cast<int32_t>(__zero_stack_offset()) - 4);
    edi3 = 1;

    if (a1)
    {
        eax4 = _usrnum;

        v5 = eax4->f0;

        al6 = _can_see(v5, a1, reinterpret_cast<int32_t>(ebp2) - 28, reinterpret_cast<int32_t>(ebp2) - 32);

        if (al6)
        {
            edx7 = _margc;
            
            if (reinterpret_cast<int1_t>(edx7->f0 == 1))
            {
                ecx8 = _usrnum;
                v9 = ecx8->f0;
                _display_room_desc(v9, 1, 0, 0xff, 0);
                
                if (!a1->f1526) 
                {
                    fun_478c28(ecx8, 0x48893e, edi10, esi11);
                    fun_478c28(0x48893e, "%s is looking around the room.\r", &a1->f30, edi10);
                    edx12 = _usrnum;
                    v13 = edx12->f0;
                    v14 = a1->f200;
                    v15 = a1->f196;
                    _tell_room(0x48893e, v15, v14, v13, 0xff, 0, 1, 1, 0xff);
                    goto addr_452734_6;
                }
            }

            ecx16 = _margc;

            if (reinterpret_cast<int32_t>(ecx16->f0) < 2)
            {
                edi3 = 0;
                goto addr_452734_6;
            }

            eax17 = _margv;
            v18 = eax17->f4;
            eax19 = _parse_command(reinterpret_cast<int32_t>(ebp2) - 4, v18);

            if (!eax19) 
                goto addr_4523e9_10;

            if (v20 < 10) 
                goto addr_451f99_12;

        } 
        else 
        {
            eax21 = 1;
            goto addr_452736_14;
        }

    } 
    else
    {
        eax21 = 0;
        goto addr_452736_14;
    }

    addr_4523e9_10:
    fun_478ba4(ecx16);
    ecx22 = _margv;
    v23 = ecx22->f4;
    v24 = a1->f196;
    v25 = a1->f200;
    eax26 = _find_action_target(v25, v24, v23, reinterpret_cast<int32_t>(ebp2) - 16, reinterpret_cast<int32_t>(ebp2) - 20, reinterpret_cast<int32_t>(ebp2) - 24, 0xf037);
    esi27 = eax26;
    if (!(v28 & 32)) 
        goto addr_452482_16;
    eax29 = _usrnum;
    v30 = eax29->f0;

    al31 = _is_inside_autocombat();

    if (!al31)
    {
        _terminate_multiple_matches(v30);
        eax21 = 1;
    }
    else 
    {
        ecx22 = _margv;
        v32 = ecx22->f4;
        eax33 = _usrnum;
        v34 = eax33->f0;
        eax35 = _match_combat_target(v34, v32, reinterpret_cast<int32_t>(ebp2) - 16);
        esi27 = eax35;
        if (v36) {
            addr_452482_16:
            _terminate_multiple_matches(ecx22);
            if (v37) {
                if (v38 != 1) {
                    if (v39 != 2) {
                        if (v40 != 8) {
                            if (v41 != 4) {
                                if (v42 != 16) {
                                    fun_478c28(1, 0x4888d8, edi10, esi11);
                                    fun_478c28(0x4888d8, "Why would you want to look at that?\r", edi10, esi11);
                                    ecx43 = _usrnum;
                                    _tell_user(ecx43);
                                    goto addr_452734_6;
                                } else {
                                    _display_spell_desc(1);
                                    goto addr_452734_6;
                                }
                            } else {
                                _display_item_desc(1);
                                goto addr_452734_6;
                            }
                        } else {
                            _display_item_desc(1);
                            goto addr_452734_6;
                        }
                    } else {
                        _display_monster_desc(1);
                        goto addr_452734_6;
                    }
                } else {
                    eax44 = _get_player(1);
                    ecx45 = esi27;
                    if (!eax44 || (edx46 = _usrnum, ecx45 = edx46->f0, ecx45 != esi27) && (eax44->f1526 && !(a1->f1781 & 32))) {
                        fun_478c28(ecx45, 0x4888d8, edi10, esi11);
                        fun_478ba4(0x4888d8);
                        eax47 = _margv;
                        v48 = eax47->f4;
                        fun_478c28(0x4888d8, "You do not see %s here!\r", v48, edi10);
                        _tell_user(0x4888d8);
                        goto addr_452734_6;
                    } else {
                        _display_user_desc();
                        if (!eax44->f1526 && !a1->f1526) {
                            fun_478c28(esi27, 0x48893e, edi10, esi11);
                            fun_478c28(0x48893e, 0x488e46, edi10, esi11);
                            ecx49 = reinterpret_cast<struct s1*>(&eax44->f30);
                            fun_478c28(ecx49, "%s looks %s up and down.\r", &a1->f30, ecx49);
                            edx50 = _usrnum;
                            v51 = edx50->f0;
                            v52 = a1->f200;
                            v53 = a1->f196;
                            _tell_room(ecx49, v53, v52, v51, esi27, 0, 1, 1, 0xff);
                        }
                        if (!a1->f1526 && (ecx54 = _usrnum, ecx54->f0 != esi27))
                        {
                            fun_478c28(ecx54, 0x488e75, edi10, esi11);
                            fun_478c28(0x488e75, "%s is looking at you.\r", &a1->f30, edi10);
                            _prf_prompt(0x488e75);
                            _tell_user(esi27);
                            goto addr_452734_6;
                        }
                    }
                }
            } else {
                edx55 = _margv;
                v56 = edx55->f4;
                ecx57 = _usrnum;
                v58 = ecx57->f0;
                al59 = _display_item_in_shop(v58, v56);

                if (al59 || (eax60 = _margv, v61 = eax60->f4, edx62 = _usrnum, v63 = edx62->f0, al64 = _display_coin_description(v63, v61), !!al64)) {
                    addr_452734_6:
                    eax21 = edi3;
                } else {
                    v65 = a1->f196;
                    v66 = a1->f200;
                    eax67 = _get_room_data(ecx57, v66, v65);
                    if (!eax67 || (!eax67->f1460 || (v68 = eax67->f1460, eax69 = _usrnum, v70 = eax69->f0, al71 = _perform_special_command(v70, v68), al71 == 0))) {
                        eax72 = _margv;
                        v73 = eax72->f4;
                        eax74 = _h_ljnsame(v73, &a1->f30);
                        if (!eax74) {
                            fun_478c28(ecx57, 0x4888d8, edi10, esi11);
                            fun_478ba4(0x4888d8);
                            ecx75 = _margv;
                            v76 = ecx75->f4;
                            fun_478c28(ecx75, "You do not see %s here!\r", v76, edi10);
                            _tell_user(ecx75);
                            goto addr_452734_6;
                        } else {
                            _display_user_desc();
                            goto addr_452734_6;
                        }
                    } 
                    else
                    {
                        _prf_prompt(ecx57);
                        ecx77 = _usrnum;
                        _tell_user(ecx77);
                        eax21 = 1;
                    }
                }
            }
        } 
        else
        {
            _terminate_multiple_matches(ecx22);
            eax21 = 1;
        }
    }

    addr_452736_14:
    return eax21;
    addr_451f99_12:
    ecx78 = _usrnum;
    v79 = ecx78->f0;
    eax80 = fun_416ac7();
    v81 = a1->f196;
    eax82 = _get_room_data(v79, eax80, v81);

    if (!eax82 || !*reinterpret_cast<int32_t*>(reinterpret_cast<int32_t>(eax82) + v83 * 4 + 0x338))
    {
        fun_478c28(v79, 0x4888d8, edi10, esi11);

        if (v84 != 8)
        {
            if (v85 != 9)
            {
                v86 = *reinterpret_cast<struct s1**>(v87 * 4 + 0x47febc);
                fun_478c28(0x4888d8, "There are no exits to the %s!\r", v86, edi10);
            } 
            else
            {
                fun_478c28(0x4888d8, "There are no exits downwards!\r", edi10, esi11);
            }
        } else {
            fun_478c28(0x4888d8, "There are no exits upwards!\r", edi10, esi11);
        }
        ecx88 = _usrnum;
        _tell_user(ecx88);
    } else {
        v89 = a1->f196;
        eax90 = *reinterpret_cast<uint16_t*>(reinterpret_cast<int32_t>(eax82) + reinterpret_cast<int32_t>(v91) * 2 + 0x360);
        if (eax90 > 22) 
            goto addr_4521de_50;
        *reinterpret_cast<signed char*>(&eax90) = *reinterpret_cast<signed char*>(eax90 + reinterpret_cast<int32_t>(fun_452000));
        goto *reinterpret_cast<int32_t*>(eax90 * 4 + 0x452017);
    }
    addr_4523e2_52:
    eax21 = 1;
    goto addr_452736_14;
    if (!*reinterpret_cast<int32_t*>(reinterpret_cast<int32_t>(eax82) + v92 * 4 + 0x3d8)) {
        addr_4521de_50:
        ecx93 = a1->f196;
        if (!a1->f1526) {
            fun_478c28(ecx93, 0x48893e, edi10, esi11);
            ecx94 = reinterpret_cast<struct s1*>(0x48893e);
            if (v95 != 8) {
                if (v96 != 9) {
                    ecx94 = v97;
                    v98 = *reinterpret_cast<struct s1**>(reinterpret_cast<int32_t>(ecx94) * 4 + 0x47febc);
                    fun_478c28(ecx94, "%s is looking to the %s.\r", &a1->f30, v98);
                } else {
                    fun_478c28(0x48893e, "%s is looking down.\r", &a1->f30, edi10);
                }
            } else {
                fun_478c28(0x48893e, "%s is looking up.\r", &a1->f30, edi10);
            }
            edx99 = _usrnum;
            v100 = edx99->f0;
            v101 = a1->f200;
            v102 = a1->f196;
            _tell_room(ecx94, v102, v101, v100, 0xff, 0, 1, 1, 0xff);
        }
    } else {
        v103 = *reinterpret_cast<struct s1**>(reinterpret_cast<int32_t>(eax82) + v104 * 4 + 0x3d8);
        eax105 = _get_message_data();
        if (eax105) {
            fun_478c28(v103, "%s\r", &eax105->f4, edi10);
            _tell_user(v103);
            goto addr_4523e2_52;
        }
    }
    v106 = *reinterpret_cast<int32_t*>(reinterpret_cast<int32_t>(eax82) + v107 * 4 + 0x338);
    eax108 = _usrnum;
    v109 = eax108->f0;
    fun_416ae6(v109, v106, v89, 1);
    v110 = eax82->f1084;
    v111 = a1->f196;
    v112 = a1->f200;
    ecx113 = _usrnum;
    v114 = ecx113->f0;
    _user_allowed_in_room(v114, v112, v111, v110, 1);
    eax115 = _usrnum;
    v116 = eax115->f0;
    _display_room_desc(v116, 1, 1, 0xff, 1);
    if (!a1->f1526) {
        fun_478c28(ecx113, 0x488db7, edi10, esi11);
        if (*reinterpret_cast<int32_t*>(v117 * 4 + 0x47fe94) != 8) {
            if (*reinterpret_cast<int32_t*>(v118 * 4 + 0x47fe94) != 9) {
                v119 = *reinterpret_cast<struct s1**>(*reinterpret_cast<int32_t*>(reinterpret_cast<int32_t>(v120) * 4 + 0x47fe94) * 4 + 0x47febc);
                fun_478c28(v120, "%s peeks in from the %s!\r", &a1->f30, v119);
            } else {
                fun_478c28(0x488db7, "%s peeks in from below!\r", &a1->f30, edi10);
            }
        } else {
            ecx121 = reinterpret_cast<struct s1*>(&a1->f30);
            fun_478c28(ecx121, "%s peeks in from above!\r", ecx121, edi10);
        }
        ecx122 = _usrnum;
        v123 = ecx122->f0;
        v124 = a1->f200;
        v125 = a1->f196;
        _tell_room(ecx122, v125, v124, v123, 0xff, 0, 1, 1, 0xff);
    }
    eax126 = _usrnum;
    v127 = eax126->f0;
    fun_416ae6(v127, eax80, ecx93, 1);
    goto addr_4523e2_52;
    addr_45208d_70:
    fun_478c28(v91, 0x4888d8, edi10, esi11);
    if (v128 != 8) {
        if (v129 != 9) {
            ecx130 = v131;
            v132 = *reinterpret_cast<struct s1**>(reinterpret_cast<int32_t>(ecx130) * 4 + 0x47febc);
            fun_478c28(ecx130, "There are no exits to the %s!\r", v132, edi10);
        } else {
            fun_478c28(0x4888d8, "There are no exits downwards!\r", edi10, esi11);
            ecx130 = reinterpret_cast<struct s1*>("There are no exits downwards!\r");
        }
    } else {
        fun_478c28(0x4888d8, "There are no exits upwards!\r", edi10, esi11);
        ecx130 = reinterpret_cast<struct s1*>("There are no exits upwards!\r");
    }
    _tell_user(ecx130);
    goto addr_4523e2_52;
    if (*reinterpret_cast<int16_t*>(reinterpret_cast<int32_t>(eax82) + reinterpret_cast<int32_t>(v133) * 2 + 0x39c) != 2) 
        goto addr_4521de_50;
    fun_478c28(v133, 0x4888d8, edi10, esi11);
    ecx134 = reinterpret_cast<struct s1*>(0x4888d8);
    if (v135 != 8) {
        if (v136 != 9) {
            v137 = *reinterpret_cast<struct s1**>(v138 * 4 + 0x47febc);
            fun_478c28(0x4888d8, "There are no exits to the %s!\r", v137, edi10);
        } else {
            fun_478c28(0x4888d8, "There are no exits downwards!\r", edi10, esi11);
            ecx134 = reinterpret_cast<struct s1*>("There are no exits downwards!\r");
        }
    } else {
        fun_478c28(0x4888d8, "There are no exits upwards!\r", edi10, esi11);
        ecx134 = reinterpret_cast<struct s1*>("There are no exits upwards!\r");
    }
    _tell_user(ecx134);
    goto addr_4523e2_52;
    v89 = *reinterpret_cast<struct s1**>(reinterpret_cast<int32_t>(eax82) + v139 * 4 + 0x374);
    goto addr_4521de_50;
    if (!*reinterpret_cast<int32_t*>(reinterpret_cast<int32_t>(eax82) + v140 * 4 + 0x374)) 
        goto addr_4521de_50;
    fun_478c28(v91, "The door is closed in that direction!\r", edi10, esi11);
    ecx141 = _usrnum;
    _tell_user(ecx141);
    goto addr_4523e2_52;
    if (*reinterpret_cast<unsigned char*>(reinterpret_cast<int32_t>(eax82) + v142 * 4 + 0x374) & 8) 
        goto addr_4521de_50;
    if (*reinterpret_cast<unsigned char*>(reinterpret_cast<int32_t>(eax82) + v143 * 4 + 0x374) & 8) 
        goto addr_4521de_50; else 
        goto addr_45208d_70;
    if (!*reinterpret_cast<int16_t*>(reinterpret_cast<int32_t>(eax82) + v144 * 2 + 0x39c)) 
        goto addr_4521de_50;
    fun_478c28(v91, "The door is closed in that direction!\r", edi10, esi11);
    ecx145 = _usrnum;
    _tell_user(ecx145);
    goto addr_4523e2_52;
}
