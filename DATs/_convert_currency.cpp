void** _convert_currency(void** ecx, void** runic, void** platinum, void** gold, void** silver, void** copper)
 {
    int tmpCopper;
    int tmpSilver;
    int tmpGold;
    int tmpPlatinum;

    int totalRunic;
    int totalPlatinum;
    int totalGold;
    int totalSilver;

    tmpCopper = copper;
    tmpSilver = silver;
    tmpGold = gold;
    tmpPlatinum = platinum;

    totalRunic = runic * 100;

    if ((totalRunic) < (runic))
    {
        totalRunic = runic;
    }

    if ((tmpPlatinum) <= ((totalRunic) + (tmpPlatinum)))
    {
        tmpPlatinum = ((tmpPlatinum) + (totalRunic));
    }

    totalPlatinum = ((tmpPlatinum) * (100));
    
    if ((tmpPlatinum) > (totalPlatinum))
    {
        totalPlatinum = tmpPlatinum;
    }

    if ((tmpGold) <= ((totalPlatinum) + (tmpGold)))
    {
        tmpGold = ((tmpGold) + (totalPlatinum));
    }

    totalGold = ((tmpGold) * (10));
    
    if ((tmpGold) > (totalGold))
    {
        totalGold = tmpGold;
    }

    if ((tmpSilver) <= ((totalGold) + (tmpSilver)))
    {
        tmpSilver = ((tmpSilver) + (totalGold));
    }

    totalSilver = ((tmpSilver) * (10));
    
    if ((tmpSilver) > (totalSilver))
    {
        totalSilver = tmpSilver;
    }

    if ((tmpCopper) <= ((totalSilver) + (tmpCopper))) 
    {
        tmpCopper = ((tmpCopper) + (totalSilver));
    }

    return tmpCopper;
}