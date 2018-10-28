      

        int resultOne = (((((player.Level)))) / 10 + (((player.MaxIntellect)) & 0xffffffce) / 10 + (((player.MaxAgility)) & 0xffffffce) / 20 + ((((player.MaxCharm)) & 0xffffffce) / 30));
      
        if (resultOne <= 75)
        {
            if (resultOne < 1)
            {
                resultOne = 1;
            }
        } 
        else 
        {
            resultOne = 75;
        }

        dodgeValue = _get_user_ability_value(ecx97, Dodge, 0xff, player, 0, 0);

        maxCharm = player.MaxCharm / 10;   
        maxAgility = player.MaxAgility / 5;     
        playerLvel = player.Level / 5;

        dodgeValue = (((((dodgeValue) + ((resultOne) + (ebx9 + 0x7b4))) + (maxCharm)) + (maxAgility)) + (playerLvel));

        (player.MartialArts) = (dodgeValue);

        playerHasJK = _user_has_ability(JumpKick);

        if (playerHasJK)
        {
            jkResult = ((player.MartialArts) + ((player.Level)));
            jkResult  = ((jkResult ) + (jkResult ));
            player.MartialArts = jkResult;
        }