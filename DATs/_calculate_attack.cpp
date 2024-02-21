
struct s0 {
    int32_t f0;
    signed char[16] pad20;
    int32_t f20;
    int32_t f24;
    int32_t f28;
    signed char[548] pad580;
    int32_t f580;
};

struct s1 {
    signed char[4] pad4;
    int32_t f4;
    int32_t f8;
    int32_t f12;
    int32_t f16;
    signed char[12] pad32;
    int32_t f32;
    signed char[548] pad584;
    int32_t f584;
};

int32_t g495fd4;

int32_t g495fd8;

int32_t g495fdc;

int32_t g495fe0;

int32_t g495fe4;

int32_t g495fd0;

int32_t g4877e4 = 5;

int32_t fun_478cb2(int32_t a1, int32_t a2);

int32_t* _calculate_attack(struct s0* a1, struct s1* a2) 
{
    int32_t* eax3;
    int32_t edx4;
    int32_t v5;
    int32_t ecx6;
    int32_t v7;
    int32_t eax8;
    int32_t eax9;
    int32_t eax10;
    int1_t zf11;
    int32_t ecx12;
    int32_t ecx13;
    int32_t eax14;
    int32_t eax15;
    int32_t eax16;
    int1_t zf17;
    int1_t zf18;
    int32_t v19;
    int32_t eax20;
    int32_t tmp32_21;
    int32_t ebx22;
    int32_t eax23;
    int32_t edx24;
    int1_t zf25;
    int1_t zf26;
    int1_t zf27;
    int32_t edx28;
    int32_t eax29;
    int32_t eax30;
    int1_t less_or_equal31;
    int1_t zf32;

    g495fd4 = 0;
    g495fd8 = 0;
    g495fdc = 0;
    g495fe0 = 0;
    g495fe4 = 0;
    g495fd0 = 0;

    if (!a1 || !a2) 
    {
        eax3 = reinterpret_cast<int32_t*>(0);
    } 
    else 
    {
        edx4 = g4877e4;

        switch (edx4)
        {
        default:
            v5 = 0;
            ecx6 = 0;
            break;
        case 1:
            v5 = 0;
            ecx6 = 0;
            break;
        case 2:
            v5 = 0;
            ecx6 = 33;
            break;
        case 3:
            v5 = 0;
            ecx6 = 66;
            break;
        case 4:
            v5 = 0;
            ecx6 = 0;
            a1->f580 = 0;
            break;
        case 6:
            v5 = -15;
            ecx6 = 10;
            a1->f580 = 0;
            break;
        case 7:
            v5 = -25;
            ecx6 = 20;
            a1->f580 = 0;
            break;
        case 8:
            v5 = -75;
            ecx6 = 0x7d;
            a1->f580 = 0;
        }

        v7 = v5 + a2->f584;
        
        if (ecx6) 
        {
            eax8 = (ecx6 + 100) * a1->f24; // WeaponNumber, mainhand.
            __asm__("cdq ");
            a1->f24 = eax8 / 100;
            __asm__("cdq ");
            a1->f28 = (ecx6 + 100) * a1->f28 / 100;
        }

        g495fe4 = a1->f20;
        eax9 = fun_478cb2(1, 100);

        if (a2->f32 >= 0 || (eax10 = fun_478cb2(0, 100), eax10 <= a2->f32 + 100))
        {
            zf11 = g4877e4 == 4;

            if (!zf11)
            {
                __asm__("cdq ");
                __asm__("cdq ");
                ecx12 = (a1->f0 + v7) * (a1->f0 + v7) / 14 / 10;
                
                if (!ecx12)
                {
                    ecx13 = 5;
                } 
                else
                {
                    __asm__("cdq ");
                    ecx13 = 100 - (a2->f4 + a2->f8) * (a2->f4 + a2->f8) / ecx12;
                }
            } 
            else
            {
                ecx13 = a1->f0 - a2->f4;
            }

        } 
        else
        {
            ecx13 = 99;
        }

        if (ecx13 >= 10)
        {
            if (ecx13 > 99)
            {
                ecx13 = 99;
            }

        } 
        else
        {
            ecx13 = 10;
        }

        if (a1->f580 > 40) {
            eax14 = a1->f580 - 40;
            __asm__("cdq ");
            ecx13 = ecx13;
            a1->f580 = eax14 / 3 + 40;
        }
        if (ecx13 <= eax9) {
            addr_42bb15_29:
            eax15 = g495fd4;
            g495fd8 = eax15;
            eax3 = reinterpret_cast<int32_t*>(0x495fd0);
        }
        else
        {
            eax16 = fun_478cb2(0, 100);
            
            if (eax16 < a1->f580 && ((zf17 = g4877e4 == 7, !zf17) && (zf18 = g4877e4 == 6, !zf18))) {
                g495fd0 = 4;
                a1->f24 = a1->f28 + a1->f28;
                a1->f28 = a1->f28 << 2;
            }
            if (a1->f24 > a1->f28) {
                a1->f28 = a1->f24;
            }
            v19 = a1->f28 - a1->f24 + 1;
            eax20 = fun_478cb2(0, v19);
            g495fd4 = eax20;
            tmp32_21 = g495fd4 + a1->f24;
            g495fd4 = tmp32_21;
            __asm__("cdq ");
            g495fd4 = g495fd4 - a2->f12 / 10;
            if (a1->f0 <= 8) {
                ebx22 = 0;
            } else {
                eax23 = a2->f32 + a2->f32;
                edx24 = a1->f0;
                if (edx24 < 0) {
                    edx24 = edx24 + 7;
                }
                __asm__("cdq ");
                ebx22 = (eax23 + eax23 * 4) / (edx24 >> 3);
            }
            if (ebx22 > 95) {
                ebx22 = 95;
            }
            zf25 = g4877e4 == 4;
            if (zf25) {
                __asm__("cdq ");
                ebx22 = ebx22 / 5;
            }
            zf26 = g4877e4 == 6;
            if (!zf26) {
                zf27 = g4877e4 == 7;
                if (zf27) {
                    edx28 = g495fd4;
                    g495fd4 = edx28 + edx28 * 4;
                }
            } else {
                eax29 = g495fd4;
                g495fd4 = eax29 + eax29 * 2;
            }
            if (a2->f32 <= 0) 
                goto addr_42baf1_48;
            eax30 = fun_478cb2(0, 100);
            if (ebx22 <= eax30) 
                goto addr_42baf1_48; else 
                goto addr_42bae2_50;
        }
    }
    addr_42bb1d_51:
    return eax3;
    addr_42baf1_48:
    less_or_equal31 = g495fd4 <= 0;
    if (!less_or_equal31) {
        zf32 = g495fd0 == 4;
        if (!zf32) {
            g495fd0 = 2;
        }
        g495fe0 = a2->f16;
        goto addr_42bb15_29;
    } else {
        g495fd4 = 0;
        g495fd0 = 1;
        goto addr_42bb15_29;
    }
    addr_42bae2_50:
    g495fd0 = 3;
    g495fd4 = 0;
    eax3 = reinterpret_cast<int32_t*>(0x495fd0);
    goto addr_42bb1d_51;
}
