using ReMUD.Game.Btrieve;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.SupportTypes;
using ReMUD.Game.Structures.Utilities;
using System;

namespace ReMUD.Game
{
    /// <summary>
    /// The GameManager class will manage all the logic i the game currently.
    /// </summary>
    public class GameManager
    {
        public MetaContentManager ContentManager = new MetaContentManager();
        private int _nextBuffer = 0;
        public string ContentDirectory = string.Empty;
        private Random _rng = new Random((int)DateTime.Now.ToBinary());

        public int _get_random(int minimum, int maximum, int variance = 0)
        {
            return _rng.Next(minimum, maximum) + variance;
        }

        public void _internal_error(string message, params object[] parameters)
        {
            LogManager.Log(message, parameters);
        }

        public void _log(string message, params object[] parameters)
        {
            LogManager.Log(message, parameters);
        }

        public bool sameas(string stg1, string stg2)
        {
            return stg1.ToLower().Equals(stg2.ToLower());
        }

        public PlayerType _get_player(int userId)
        {
            PlayerType playerInfo = new PlayerType();

            string errorMessage = string.Empty;

            //if (UserManager.UserIdExists(userId) == false)
            //{
            //    errorMessage = "get_player: {0} (user number: {1} [{2}])";

            //    _internal_error(errorMessage, userId, userId, UserManager.GetUsername(userId));
            //}
            //else
            //{
            //    string username = UserManager.GetUsername(userId);

            //    playerInfo = ContentManager.Select<PlayerManager>().Select(username);            
            //}

            return playerInfo;
        }

        public void _save_player(PlayerType player)
        {
            ushort saveStatus = 0;// GameContentManager.PlayerContentManager.Save(playerInfo);

            switch (saveStatus)
            {
                case BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY:
                    _log("Player {0} saved.", player.GetUsername());
                    break;
                default:
                    _internal_error(BtrieveTypes.BtrieveErrorCode(saveStatus));
                    break;
            }
        }

        public SpellType? _get_spell_data(int spellId)
        {
            return ContentManager.Select<SpellManager>().Select(spellId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ecx"></param>
        /// <param name="a2">Ability ID</param>
        /// <param name="a3"></param>
        /// <param name="a4"></param>
        /// <returns></returns>
        public bool _spell_has_ability(int abilityId, int abilityValue, int spellId)
        {
            SpellType? spell = _get_spell_data(spellId);

            if (spell.HasValue == true)
            {
                for (int i = 0; i < spell.Value.AbilityId.Length; i++)
                {
                    if (spell.Value.AbilityId[i] == abilityId)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool _user_is_wearing(PlayerType player, object a2, int itemId)
        {
            for (int i = 0; i < player.WornItem.Length; i++)
            {
                if (player.WornItem[i].Equals(itemId) == true)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a2">Npc ID</param>
        /// <param name="a8"></param>
        /// <param name="spell"></param>
        /// <param name="duration"></param>
        public void _add_cast_spell_to_monster(int a2, PlayerType a8, SpellType spell, int duration)
        {

            //            void** _add_cast_spell_to_monster(void** ecx, void** a2, void** a3, void** a4, void** a5, void** a6, void** a7, void** player)
            //            
            //                v9 = ebx10;
            //                v11 = esi12;
            //                v13 = edi14;
            //                spell = a6;
            NonPlayerCharacterType? npc = _get_monster_data(a2);

            if (npc == null)
            {
                return;
            }
            else
            {
                int tmpLevel = 0;
                //{
                //    addr_43ef1c_2:
                //    eax18 = (0xffffffff);
                //}
                //else
                //{
                //    if (player)
                //    {
                if ((spell.LevelCap) <= 0 || (uint)(((ushort)((a8.Level)))) <= (((spell.LevelCap))))
                {
                    tmpLevel = a8.Level;
                }
                else
                {
                    tmpLevel = spell.LevelCap;
                }

                if (spell.LVLSDurIncr > 0)
                {
                    int eax20 = 0;
                    eax20 = spell.LVLSDurIncr;
                    int edx21 = 0;
                    edx21 = spell.DurIncrease;

                    duration = duration + tmpLevel / eax20 * edx21;
                }

                int tmpDifficulty = spell.Difficulty * tmpLevel;

                if (tmpDifficulty > duration)
                {
                    // duration, tmpDifficulty + 1, 
                    //eax23 = fun_478cb2(a4, eax22 + 1, v13);
                    // duration = eax23;
                }


                // eax24 = _get_user_ability_value(ecx19, 0xa6, 0xff, a8, 0, 0);
                int alterSpellLength = _get_user_ability_value(a8, 0xa6);

                duration = ((alterSpellLength + 100 * (duration)) / 100);

            }

            //int ebx25 = 0;
            //do
            //{
            //    if (reinterpret_cast<int1_t>(static_cast<uint32_t>(*reinterpret_cast<uint16_t*>(uint(esi17 + reinterpret_cast < unsigned char > (ebx25) * 2) + 0x14a)) == a3))
            //        goto addr_43ee41_14;
            //    ++ebx25;
            //} while (char(ebx25) < char(5));
            //        goto addr_43ee88_16;
            //    }
            //addr_43ef1f_17:
            //    return eax18;
            //    addr_43ee41_14:
            //    * reinterpret_cast<int16_t*>(uint(esi17 + reinterpret_cast<unsigned char>(ebx25) * 2) + 0x15e) = * reinterpret_cast<int16_t*>(&a4);
            //    * reinterpret_cast<int16_t*>(uint(esi17 + reinterpret_cast<unsigned char>(ebx25) * 2) + 0x154) = * reinterpret_cast<int16_t*>(&a5);
            //    * reinterpret_cast<signed char*>(esi17 + 0x140) = 1;
            //    _display_spell_success(a7, 0xff, spell, player, esi17 + 0x8e, a5);
            //eax18 = ebx25;
            //    goto addr_43ef1f_17;
            //    addr_43ee88_16:
            //    ebx26 = (0);
            //    do {
            //        if (!* reinterpret_cast<int16_t*>(uint(esi17 + reinterpret_cast<unsigned char>(ebx26) * 2) + 0x14a)) 
            //            break;
            //        ++ebx26;
            //    } while (char(ebx26) < char (5));
            //    goto addr_43eee5_20;
            //    * reinterpret_cast<int16_t*>(uint(esi17 + reinterpret_cast<unsigned char>(ebx26) * 2) + 0x14a) = * reinterpret_cast<int16_t*>(&a3);
            //    * reinterpret_cast<int16_t*>(uint(esi17 + reinterpret_cast<unsigned char>(ebx26) * 2) + 0x15e) = * reinterpret_cast<int16_t*>(&a4);
            //    * reinterpret_cast<int16_t*>(uint(esi17 + reinterpret_cast<unsigned char>(ebx26) * 2) + 0x154) = * reinterpret_cast<int16_t*>(&a5);
            //    * reinterpret_cast<signed char*>(esi17 + 0x140) = 1;
            //    _display_spell_success(a7, 0xff, spell, player, esi17 + 0x8e, a5);
            //eax18 = ebx26;
            //    goto addr_43ef1f_17;
            //    addr_43eee5_20:
            //    zf27 = g485964 == 0;
            //    if (zf27) {
            //        fun_478c28(0x4859cc, v13, v11, v9, 0x4859cc, v13, v11, v9);
            //fun_478c28("You attempt to cast %s, but fail.\r", spell + 2, v13, v11, "You attempt to cast %s, but fail.\r", spell + 2, v13, v11);
            //_prf_prompt(0x4859cc, a7);
            //_tell_user(a7, a7, a7);
            //        goto addr_43ef1c_2;
            //    }
            //}
        }

        public void _add_cast_spell_to_user()
        {

            //TODO: Insert Logic.
        }

        public void _add_delay(ref PlayerType player, byte delay)
        {
            player.Delay += delay;
        }

        public void _add_delayed_command()
        {

            //TODO: Insert Logic.
        }

        public void _add_duration_spell_to_room()
        {

            //TODO: Insert Logic.
        }

        public void _add_evil_points(ref PlayerType player, int ePoints)
        {
            // 1. _get_player.
            // _get_player().

            // 2. _get_legal_level.
            int currentEvilPoints = player.EvilPoints;
            int legalLevel = _get_legal_level(currentEvilPoints);



            //TODO: Insert Logic.
        }

        public void _add_evil_timer()
        {

            //TODO: Insert Logic.
        }

        public void _add_evil_warnings_to_room()
        {

            //TODO: Insert Logic.
        }

        public void _add_exit_to_list()
        {

            //TODO: Insert Logic.
        }

        public void _add_experience()
        {

            //TODO: Insert Logic.
        }

        public void _add_item_to_inventory()
        {

        }

        public void _add_item_to_room()
        {

            //TODO: Insert Logic.
        }

        public void _add_logical_to_monster()
        {

            //TODO: Insert Logic.
        }

        public void _add_logical_to_room()
        {

            //TODO: Insert Logic.
        }

        public void _add_logical_to_user()
        {

            //TODO: Insert Logic.
        }

        public void _add_monster_to_room()
        {

            //TODO: Insert Logic.
        }

        public void _add_multiple_option()
        {

            //TODO: Insert Logic.
        }

        public void _add_quest_exp()
        {

            //TODO: Insert Logic.
        }

        public void _add_spell_to_spellbook()
        {

            //TODO: Insert Logic.
        }

        public void _add_to_group(string username)
        {
            // PlayerEntity player = GameContentManager.PlayerContentManager.GetPlayer(username);

            //edi5 = a3;
            //eax9 = _get_player(ecx, a2, edi6, esi7, ebx8);
            //ecx10 = a2;
            //esi11 = eax9;
            //edx12 = 0;
            //eax13 = 0;
            //if (edi5 != a2)
            //{
            //    if (esi11)
            //    {
            //        ebx14 = 0;
            //        while (!*reinterpret_cast < signed char*> (&eax13) && ebx14 < 5) {
            //            ecx10 = reinterpret_cast<void**>(static_cast<int32_t>(*reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + ebx14 * 2) + 0x6ae)));
            //            if (edi5 == ecx10)
            //            {
            //                *reinterpret_cast < signed char*> (&eax13) = 1;
            //            }
            //            ++ebx14;
            //        }
            //        if (*reinterpret_cast < signed char*> (&eax13)) 
            //    goto addr_41e0ef_9;
            //        if (!a4)
            //            goto addr_41e0cc_11;
            //    }
            //    else
            //    {
            //        eax15 = 0;
            //        goto addr_41e164_13;
            //    }
            //}
            //else
            //{
            //    eax15 = 0;
            //    goto addr_41e164_13;
            //}
            //addr_41e0ef_9:
            //if (!*reinterpret_cast < signed char*> (&eax13) || !a4) {
            //    eax15 = edx12;
            //} else {
            //    ebx16 = 0;
            //    do
            //    {
            //        eax17 = _usrnum;
            //        v18 = *reinterpret_cast<void***>(eax17);
            //        _tell_user(ecx10, v18, v18);
            //        ecx10 = v18;
            //        if (*reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + ebx16 * 2) + 0x6ae) != -1)
            //        {
            //            v19 = reinterpret_cast<void**>(static_cast<int32_t>(*reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + ebx16 * 2) + 0x6ae)));
            //            _add_to_group(ecx10, v19, a2, 0);
            //            edi20 = 0;
            //            do
            //            {
            //                if (*reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + edi20 * 2) + 0x6ae) != -1)
            //                {
            //                    v21 = reinterpret_cast<void**>(static_cast<int32_t>(*reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + edi20 * 2) + 0x6ae)));
            //                    v22 = reinterpret_cast<void**>(static_cast<int32_t>(*reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + ebx16 * 2) + 0x6ae)));
            //                    _add_to_group(ecx10, v22, v21, 0);
            //                }
            //                ++edi20;
            //            } while (edi20 < 5);
            //        }
            //        ++ebx16;
            //    } while (ebx16 < 5);
            //    *reinterpret_cast < signed char*> (&eax15) = 1;
            //}
            //addr_41e164_13:
            //return *reinterpret_cast < signed char*> (&eax15);
            //addr_41e0cc_11:
            //ebx23 = 0;
            //while (!*reinterpret_cast < signed char*> (&edx12) && ebx23 < 5) {
            //    if (*reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + ebx23 * 2) + 0x6ae) == -1)
            //    {
            //        *reinterpret_cast<int16_t*>(reinterpret_cast<uint32_t>(esi11 + ebx23 * 2) + 0x6ae) = *reinterpret_cast<int16_t*>(&edi5);
            //        *reinterpret_cast < signed char*> (&edx12) = 1;
            //    }
            //    ++ebx23;
            //}
            //goto addr_41e0ef_9;


        }

        public void _addon_adding_life_to_user()
        {

            //TODO: Insert Logic.
        }

        public void _addon_adjust_user_wealth()
        {

            //TODO: Insert Logic.
        }

        public void _alloc_get_spell_data()
        {

            //TODO: Insert Logic.
        }

        public void _allocate_buffers()
        {

            //TODO: Insert Logic.
        }

        public void _already_evil()
        {

            //TODO: Insert Logic.
        }

        public void _ask_monster_a_question()
        {

            //TODO: Insert Logic.
        }

        public void _attack_monster_monster()
        {

            //TODO: Insert Logic.
        }

        public void _attack_monster_user()
        {

            //TODO: Insert Logic.
        }

        public void _attack_user_monster()
        {

            //TODO: Insert Logic.
        }

        public void _attack_user_user()
        {

            //TODO: Insert Logic.
        }

        public void _attacker_is_in_same_room()
        {

            //TODO: Insert Logic.
        }

        public void _attacker_type()
        {

            //TODO: Insert Logic.
        }

        public void _attempt_to_forgive()
        {

            //TODO: Insert Logic.
        }

        public void _automatic_update_polling_routine()
        {

            //TODO: Insert Logic.
        }

        public void _background_energy()
        {

            //TODO: Insert Logic.
        }

        public void _background_fast()
        {

            //TODO: Insert Logic.
        }

        public void _background_inactivity()
        {

            //TODO: Insert Logic.
        }

        public void _background_medium()
        {

            //TODO: Insert Logic.
        }

        public void _background_monster_create()
        {

            //TODO: Insert Logic.
        }

        public void _background_other()
        {

            //TODO: Insert Logic.
        }

        public void _background_save_buffers()
        {

            //TODO: Insert Logic.
        }

        public void _background_slow()
        {

            //TODO: Insert Logic.
        }

        public void _background_update_exits()
        {

            //TODO: Insert Logic.
        }

        public void _begin_clearing_evil_points()
        {

            //TODO: Insert Logic.
        }

        public void _begin_clearing_permanent_info()
        {

            //TODO: Insert Logic.
        }

        public void _begin_refreshing_limited_items()
        {

            //TODO: Insert Logic.
        }

        public void _begin_updating()
        {

            //TODO: Insert Logic.
        }

        public void _begin_user_item_xref()
        {

            //TODO: Insert Logic.
        }

        public void _begin_user_xref()
        {

            //TODO: Insert Logic.
        }

        public void _borrow_gold()
        {

            //TODO: Insert Logic.
        }

        public void _build_kai_power_cache()
        {

            //TODO: Insert Logic.
        }

        public void _buy_item()
        {

            //TODO: Insert Logic.
        }

        public void _calc_exp_needed()
        {

            //TODO: Insert Logic.
        }

        public void _calc_minutes_difference()
        {

            //TODO: Insert Logic.
        }

        public void _calculate_attack()
        {

            //TODO: Insert Logic.
        }

        public void _calculate_secondary_stats(ref PlayerType player)
        {
            // Get the FindTraps ability value.
            bool findTrapExists = _user_has_ability(player, AbilityTypes.FindTraps);

            int tmpLevel = 0;
            // if findtraps is zero, set Traps and SubTraps to 0.
            if (findTrapExists == false)
            {
                player.Traps = 0;
                player.BaseTraps = 0;
            }
            else
            {
                if (player.Level <= 15)
                {
                    tmpLevel = player.Level;
                }
                else
                {
                    int tLevel = (player.Level & 0xFFF1) >> 1;

                    tLevel += tLevel;

                    tmpLevel = tLevel + 15;
                }

                player.Traps = (short)(((player.MaxIntellect) + (player.MaxAgility) + (player.MaxCharm + player.MaxCharm) + tmpLevel) * 28 / 7);
                player.BaseTraps = player.Traps;

                short findTrapsValue = (short)_get_user_ability_value(player, AbilityTypes.FindTraps); // Ability ID 40.

                player.Traps += findTrapsValue;

                short findTrapsAlterValue = (short)_get_user_ability_value(player, AbilityTypes.FindTrapsValue); // Ability ID 179.

                player.Traps += findTrapsAlterValue;
                player.BaseTraps = player.Traps;

                if (player.Traps < 0)
                {
                    player.Traps = 0;
                    player.BaseTraps = 0;
                }
            }

            long resultOne = (((((player.Level)))) / 10 + (((player.MaxIntellect)) & 0xffffffce) / 10 +
                (((player.MaxAgility)) & 0xffffffce) / 20 + ((((player.MaxCharm)) & 0xffffffce) / 30));

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

            int dodgeValue = _get_user_ability_value(player, AbilityTypes.Dodge);
            int crits = _get_user_ability_value(player, AbilityTypes.CriticalHit);

            var maxCharm = player.MaxCharm / 10;
            var maxAgility = player.MaxAgility / 5;
            var playerLvel = player.Level / 5;

            dodgeValue = (int)(((((dodgeValue) + ((resultOne) + (crits))) + (maxCharm)) + (maxAgility)) + (playerLvel));

            player.MartialArts = (short)(dodgeValue);

            bool hasJumpKick = _user_has_ability(player, AbilityTypes.JumpKick);

            if (hasJumpKick == true)
            {
                short jkResult = (short)((player.MartialArts) + ((player.Level)));
                jkResult = (short)((jkResult) + (jkResult));
                player.MartialArts = jkResult;
            }
        }

        public void _can_see(int x, PlayerType player, int y, int offset, RoomType room)
        {

            int lightLevel = 0;

            lightLevel = _get_light_level(player);

            if (lightLevel >= -149)
            {
                if (lightLevel <= 0x384)
                {
                    lightLevel = 1;

                }
                else
                {
                    lightLevel = 0;
                }
            }
            else
            {

            }
            //    uint eax6 = 0;
            //    uint a4 = 0;
            //    string outputMessage = string.Empty;

            //   // if (!((room.Light) & 16))
            //    {
            //        eax6 = (uint)_get_light_level(player);

            //        a4 = eax6;

            //        if (a4 >= 0xffffff6a)
            //        {
            //            if (a4 <= 0x384)
            //            {
            //                eax6 = 1;
            //            } 
            //        else 
            //        {
            //                uint v7 = a5;


            //                outputMessage = sprintf("%s\r", v7, edi8, esi9);

            //                _tell_user(outputMessage, a2);

            //                eax6 = 0;
            //            }
            //        } 
            //    else
            //    {
            //            v10 = a5;
            //            outputMessage = sprintf("The room is %s - you can't see anything\r", v10, edi8, esi9);
            //            _tell_user(outputMessage, player);
            //            eax6 = 0;
            //        }
            //    } 
            //else
            //{
            //        outputMessage = sprintf("You are blind.\r", edi8, esi9, ebx11);
            //        _tell_user("You are blind.\r", player, player);
            //        eax6 = 0;
            //    }
        }

        public string sprintf(string message, params object[] arguments)
        {
            return PrintFormatUtility.sprintf(message, arguments);

           // return string.Format(message, arguments);
        }

        public void _can_sneak()
        {

            //TODO: Insert Logic.
        }

        public void _can_user_change_race()
        {

            //TODO: Insert Logic.
        }

        public void _cast_item_target()
        {

            //TODO: Insert Logic.
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ecx"></param>
        /// <param name="a2"></param>
        /// <param name="a3"></param>
        /// <param name="a4"></param>
        /// <param name="a5"></param>
        public void _cast_monster_target(object ecx, object a2, int a3, object a4, byte a5)
        {
            //1. _get_player
            PlayerType player = _get_player(a3);
            //2. _get_monster_data
            //3. _check_confusion(0, a3, player)

            bool confused = _check_confusion(player);


            //TODO: Insert Logic.
        }

        public void _cast_no_target()
        {

            //TODO: Insert Logic.
        }

        public void _cast_user_target()
        {

            //TODO: Insert Logic.
        }

        public void _change_user_rank()
        {

            //TODO: Insert Logic.
        }

        public void _check_begin_updating()
        {

            //TODO: Insert Logic.
        }

        public bool _check_confusion(PlayerType player)
        {
            if(PlayerType.Validate(player) == false ||
              (player.OffSet_x6EC_x6FB[8] & 0x80) == 0)
            {
                return false;
            }
            else
            {
                _update_dynamic_stats(player);

                int messageId = 0;

                int abilityValue = _get_user_ability_value(player, AbilityTypes.Confusion, AbilityTypes.ConfusionMessage, out messageId);

                if (((abilityValue) < (0)) || (abilityValue == 0))
                {
                    return false;
                }
                else
                {
                    if (abilityValue > _get_random(0, 100))
                    {
                        if (messageId == 0)
                        {
                            _tell_user("You look around stupidly and do nothing!\r", player, player);

                            string outputMessage = sprintf("%s looks around stupidly and foams at the mouth!\r", BtrieveUtility.ConvertToString(player.FirstName));

                            int mapId = player.MapNumber;
                            int roomId = player.RoomNumber;

                            _tell_room(outputMessage, mapId, roomId);

                            _add_delay(ref player, 1);

                            return true;
                        }
                        else
                        {
                            MessageType messageType = _get_message_data(messageId);

                            string messageOut = sprintf("%s\r", messageType.GetMessage(1));

                            _tell_user(messageOut, player, player);

                            messageOut = sprintf(messageType.GetMessage(2), BtrieveUtility.ConvertToString(player.FirstName));

                            _tell_room(sprintf("%s\r", messageOut), player.MapNumber, player.RoomNumber);

                            _add_delay(ref player, 1);

                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void _check_currency()
        {

            //TODO: Insert Logic.
        }

        public void _check_initiate_restocking()
        {

            //TODO: Insert Logic.
        }

        public void _check_kill_monster()
        {

            //TODO: Insert Logic.
        }

        public void _check_kill_user()
        {

            //TODO: Insert Logic.
        }

        public void _check_monster_confusion()
        {

            //TODO: Insert Logic.
        }

        public void _cleanup_currency()
        {

            //TODO: Insert Logic.
        }

        public void _cleanup_data_for_cs()
        {

            //TODO: Insert Logic.
        }

        public void _cleanup_pending_commands()
        {

            //TODO: Insert Logic.
        }

        public void _cleanup_when_user_leaves()
        {

            //TODO: Insert Logic.
        }

        public void _clear_autocombat_info()
        {

            //TODO: Insert Logic.
        }

        public void _clear_backstab_attack_type()
        {

            //TODO: Insert Logic.
        }

        public void _clear_bankbook()
        {

            //TODO: Insert Logic.
        }

        public void _clear_bankbooks_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_class()
        {

            //TODO: Insert Logic.
        }

        public void _clear_classes_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_evil_points_routine()
        {

            //TODO: Insert Logic.
        }

        public void _clear_forget_list()
        {

            //TODO: Insert Logic.
        }

        public void _clear_gang()
        {

            //TODO: Insert Logic.
        }

        public void _clear_gang_invitations()
        {

            //TODO: Insert Logic.
        }

        public void _clear_gangs_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_item()
        {

            //TODO: Insert Logic.
        }

        public void _clear_items_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_known_monster()
        {

            //TODO: Insert Logic.
        }

        public void _clear_known_monsters_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_message()
        {

            //TODO: Insert Logic.
        }

        public void _clear_messages_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_monster()
        {

            //TODO: Insert Logic.
        }

        public void _clear_monsters_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_permanent_routine()
        {

            //TODO: Insert Logic.
        }

        public void _clear_player()
        {

            //TODO: Insert Logic.
        }

        public void _clear_players_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_race()
        {

            //TODO: Insert Logic.
        }

        public void _clear_races_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_room()
        {

            //TODO: Insert Logic.
        }

        public void _clear_rooms_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_search_flags()
        {

            //TODO: Insert Logic.
        }

        public void _clear_shop()
        {

            //TODO: Insert Logic.
        }

        public void _clear_shops_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_spell()
        {

            //TODO: Insert Logic.
        }

        public void _clear_spell_told_flags()
        {

            //TODO: Insert Logic.
        }

        public void _clear_spells_to_null()
        {

            //TODO: Insert Logic.
        }

        public void _clear_statistics()
        {

            //TODO: Insert Logic.
        }

        public void _close_update_db()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_aid()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_any_attack()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_appraise()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_ask()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_attack()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_auction()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_backstab()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_bankbook()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_bash()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_borrow()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_broadcast()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_broadgang()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_buy()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_cast()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_close()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_create()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_demote()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_deposit()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_direct_message()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_disarm()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_disband()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_drag()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_drink()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_drop()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_eat()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_equip()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_experience()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_follow()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_forget()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_forgive()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_get()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_give()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_global()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_gossip()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_greet()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_guard()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_hide()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_identity()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_invite()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_join()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_jumpkick()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_kick()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_killblow()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_leave()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_light()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_list()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_lock()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_look(PlayerType player)
        {

            //TODO: Insert Logic.
        }

        public void _cmd_map()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_markup()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_mesmerize()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_move()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_open()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_picklock()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_promote()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_punch()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_purge()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_quit()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_repay()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_rob()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_search()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_sell()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_set()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_share()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_smash()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_sneak()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_stock()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_suicide()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_sysop()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_tame()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_topten()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_track()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_train()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_uninvite()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_unstock()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_use(PlayerType player, string command)
        {
            //        ebp4 = reinterpret_cast<void*>((uint)(__zero_stack_offset()) - 4);
            //        v5 = ebx6;
            //        v7 = esi8;
            //        v9 = edi10;
            //        edi11 = a3;
            //        esi12 = a2;
            //        v13 = (1);
            //        if (esi12)
            //        {
            //            edx14 = _margc;
            //            if (!reinterpret_cast<int1_t>((edx14) == 1))
            //            {
            //                fun_478ba4(ecx);
            //                ecx15 = _margv;
            //                v16 = (ecx15 + 4);
            //                eax17 = _usrnum;
            //                v18 = (eax17);
            //                eax19 = _find_item_in_inventory(ecx15, v18, v16, (uint)(ebp4) + 0xfffffff8, (uint)(ebp4) + 0xfffffff4, (uint)(ebp4) + 0xffffffee, (uint)(ebp4) + 0xffffffdc, 4);
            //                if (1)
            //                {
            //                    _terminate_multiple_matches(ecx15, 1);
            //                    if (!eax19 || !v20)
            //                    {
            //                        if (!eax19 || v21)
            //                        {
            //                            if (edi11 != 0x6e)
            //                            {
            //                                v22 = (esi12 + 0xc4);
            //                                v23 = (esi12 + 0xc8);
            //                                eax24 = _get_room_data(v23, v22, v9, v7, v5, v23, v22, v9, v7, v5);
            //                                if (!eax24 || (!(eax24 + 0x5b4) || (v25 = (eax24 + 0x5b4), edx26 = _usrnum, v27 = (edx26), al28 = _perform_special_command(1, v27, v25), al28 == 0)))
            //                                {
            //                                    fun_478c28(0x48c3f3, v9, v7, v5, 0x48c3f3, v9, v7, v5);
            //                                    edx29 = _margv;
            //                                    v30 = (edx29 + 4);
            //                                    fun_478c28("You don't have %s.\r", v30, v9, v7, "You don't have %s.\r", v30, v9, v7);
            //                                    ecx31 = _usrnum;
            //                                    v32 = (ecx31);
            //                                    _tell_user(ecx31, v32);
            //                                }
            //                                else
            //                                {
            //                                    ecx33 = _usrnum;
            //                                    v34 = (ecx33);
            //                                    _prf_prompt(ecx33, v34);
            //                                    eax35 = _usrnum;
            //                                    v36 = (eax35);
            //                                    _tell_user(v34, v36, v36);
            //                                    eax37 = (1);
            //                                    goto addr_46126c_10;
            //                                }
            //                            }
            //                            else
            //                            {
            //                                *reinterpret_cast < unsigned char*> (esi12 + 0x6f4) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (esi12 + 0x6f4) & 0xfbff);
            //                                *reinterpret_cast < unsigned char*> (esi12 + 0x7c8) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (esi12 + 0x7c8) & 0xfeff);
            //                                eax38 = _cmd_look(1, esi12, edi11);
            //                                v13 = eax38;
            //                            }
            //                        }
            //                        else
            //                        {
            //                            fun_478c28(0x48c3f3, v9, v7, v5, 0x48c3f3, v9, v7, v5);
            //                            fun_478c28("There are no more uses in %s.\r", eax19 + 0xad, v9, v7, "There are no more uses in %s.\r", eax19 + 0xad, v9, v7);
            //                            eax39 = _usrnum;
            //                            v40 = (eax39);
            //                            _tell_user(0x48c3f3, v40, v40);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        v41 = (eax19);
            //                        al42 = _user_can_use(1, esi12, eax19);
            //                        if (al42)
            //                        {
            //                            eax43 = _get_item_data(v41, v41);
            //                            ecx44 = v41;
            //                            ebx45 = eax43;
            //                            if (*reinterpret_cast < unsigned char*> (ebx45 + 0x398) >= 1) {
            //                                edx46 = 0;
            //                                eax47 = 0;
            //                                do
            //                                {
            //                                    ecx44 = (uint(esi12 + eax47 * 4) + 0x62c);
            //                                    if (ecx44 == (ebx45))
            //                                    {
            //                                        *reinterpret_cast < signed char*> (&edx46) = 1;
            //                                    }
            //                                    ++eax47;
            //                                } while (eax47 < 20);
            //                                if (*reinterpret_cast < signed char*> (&edx46)) 
            //                            goto addr_460ee7_20;
            //                                fun_478c28("You must be wearing that item to use it!\r", v9, v7, v5);
            //                                eax48 = _usrnum;
            //                                v49 = (eax48);
            //                                _tell_user("You must be wearing that item to use it!\r", v49, v49);
            //                                eax37 = (1);
            //                                goto addr_46126c_10;
            //                            } else {
            //                                if (*reinterpret_cast<uint16_t*>(ebx45 + 0x2f4) != 1 || (ebx45) == (esi12 + 0x624))
            //                                {
            //                                    addr_460ee7_20:
            //                                    fun_478c58(ecx44);
            //                                    edx50 = _margc;
            //                                    ecx51 = (edx50);
            //                                    if (!reinterpret_cast<int1_t>(ecx51 == &v52->f1))
            //                                    {
            //                                        fun_478ba4(ecx51);
            //                                        if (*reinterpret_cast<uint16_t*>(ebx45 + 0x2f4) == 7)
            //                                            goto addr_461054_24;
            //                                        ecx53 = _margv;
            //                                        v54 = (uint(ecx53 + v55 * 4) + 4);
            //                                        v56 = (esi12 + 0xc4);
            //                                        v57 = (esi12 + 0xc8);
            //                                        eax58 = _find_action_target(v57, v56, v54, (uint)(ebp4) + 0xffffffe4, (uint)(ebp4) + 0xffffffe0, (uint)(ebp4) + 0xffffffdc, 0xf037);
            //                                        if (!(v59 & 32))
            //                                            goto addr_460fa1_26;
            //                                        else
            //                                            goto addr_460f8f_27;
            //                                    }
            //                                    else
            //                                    {
            //                                        if (*reinterpret_cast<uint16_t*>(ebx45 + 0x2f4) != 6)
            //                                        {
            //                                            edx60 = _usrnum;
            //                                            v61 = (edx60);
            //                                            al62 = _use_no_target(ecx51, ebx45, v61, edi11);
            //                                            v63 = al62;
            //                                            goto addr_461138_30;
            //                                        }
            //                                        else
            //                                        {
            //                                            *reinterpret_cast < unsigned char*> (esi12 + 0x6f4) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (esi12 + 0x6f4) & 0xfbff);
            //                                            *reinterpret_cast < unsigned char*> (esi12 + 0x7c8) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (esi12 + 0x7c8) & 0xfeff);
            //                                            eax37 = _cmd_light(ecx51, esi12, edi11);
            //                                            goto addr_46126c_10;
            //                                        }
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    fun_478c28("You must have that item readied to use it!\r", v9, v7, v5, "You must have that item readied to use it!\r", v9, v7, v5);
            //                                    ecx64 = _usrnum;
            //                                    v65 = (ecx64);
            //                                    _tell_user(ecx64, v65);
            //                                    eax37 = (1);
            //                                    goto addr_46126c_10;
            //                                }
            //                            }
            //                        }
            //                        else
            //                        {
            //                            fun_478c28("You may not use that item!\r", v9, v7, v5, "You may not use that item!\r", v9, v7, v5);
            //                            ecx66 = _usrnum;
            //                            v67 = (ecx66);
            //                            _tell_user(ecx66, v67);
            //                            eax37 = (1);
            //                            goto addr_46126c_10;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    _terminate_multiple_matches(ecx15, 0);
            //                    eax37 = (1);
            //                    goto addr_46126c_10;
            //                }
            //            }
            //            else
            //            {
            //                if (edi11 != 0x6e)
            //                {
            //                    fun_478c28("%sSyntax: USE {Item to use} [{target}]\r", 0x48c3f3, v9, v7);
            //                }
            //                else
            //                {
            //                    fun_478c28("%sSyntax: Read {Item}\r", 0x48c3f3, v9, v7);
            //                }
            //                ecx68 = _usrnum;
            //                v69 = (ecx68);
            //                _tell_user(ecx68, v69);
            //            }
            //        }
            //        else
            //        {
            //            eax37 = (0);
            //            goto addr_46126c_10;
            //        }
            //        addr_461269_40:
            //        eax37 = v13;
            //        addr_46126c_10:
            //        return eax37;
            //        addr_460fa1_26:
            //        _terminate_multiple_matches(ecx53, 1);
            //        edx70 = _usrnum;
            //        ecx71 = (edx70) + reinterpret_cast < unsigned char> ((edx70)) * 4;
            //        eax72 = g479100;
            //        if ((eax72 + reinterpret_cast < unsigned char> (ecx71) * 4)) {
            //            fun_478c28("Target type: %d, target: %d\r", v73, v9, v7);
            //            edx74 = _usrnum;
            //            v75 = (edx74);
            //            _tell_user(ecx71, v75);
            //        }
            //        ecx76 = v77;
            //        if (reinterpret_cast < unsigned char> (ecx76) > reinterpret_cast < unsigned char> (16)) 
            //    goto addr_46101f_43;
            //        *reinterpret_cast < signed char*> (&ecx76) = *reinterpret_cast < signed char*> (reinterpret_cast < unsigned char> (ecx76) + uint(fun_460ff2));
            //        switch (ecx76)
            //        {
            //    addr_46101f_43:
            //case 0:
            //case 6:
            //    if (*reinterpret_cast<uint16_t*>(ebx45 + 0x2f4) != 6)
            //        {
            //            if (*reinterpret_cast<uint16_t*>(ebx45 + 0x2f4) != 7)
            //            {
            //                edx78 = _usrnum;
            //                v79 = (edx78);
            //                al80 = _use_no_target(ecx76, ebx45, v79, edi11);
            //                v63 = al80;
            //                break;
            //            }
            //            else
            //            {
            //                addr_461054_24:
            //                *reinterpret_cast < unsigned char*> (esi12 + 0x6f4) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (esi12 + 0x6f4) & 0xfbff);
            //                eax81 = _margv;
            //                v82 = (uint(eax81 + v83 * 4) + 4);
            //                ecx84 = ((uint)(ebp4) + 0xfffffff0);
            //                eax85 = _command(ecx84, ecx84, v82);
            //                if (!eax85 || v86 >= 10)
            //                {
            //                    v63 = 0;
            //                    break;
            //                }
            //                else
            //                {
            //                    eax87 = _usrnum;
            //                    v88 = (eax87);
            //                    al90 = _use_no_target(ecx84, ebx45, v88, v89);
            //                    v63 = al90;
            //                    break;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            *reinterpret_cast < unsigned char*> (esi12 + 0x6f4) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (esi12 + 0x6f4) & 0xfbff);
            //            *reinterpret_cast < unsigned char*> (esi12 + 0x7c8) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (esi12 + 0x7c8) & 0xfeff);
            //            eax37 = _cmd_light(ecx76, esi12, edi11);
            //            goto addr_46126c_10;
            //        }
            //case 1:
            //    eax91 = _usrnum;
            //        v92 = (eax91);
            //        al93 = _use_spell_target(ecx76, ebx45, v92, eax58, edi11);
            //        v63 = al93;
            //        break;
            //case 2:
            //    ecx94 = _usrnum;
            //        v95 = (ecx94);
            //        al96 = _use_item_target(ecx94, ebx45, v95, eax58, edi11);
            //        v63 = al96;
            //        break;
            //case 3:
            //    edx97 = _usrnum;
            //        v98 = (edx97);
            //        al99 = _use_item_target(ecx76, ebx45, v98, eax58, edi11);
            //        v63 = al99;
            //        break;
            //case 4:
            //    eax100 = _usrnum;
            //        v101 = (eax100);
            //        al102 = _use_monster_target(ecx76, ebx45, v101, eax58, edi11);
            //        v63 = al102;
            //        break;
            //case 5:
            //    ecx103 = _usrnum;
            //        v104 = (ecx103);
            //        al105 = _use_player_target(ecx103, ebx45, v104, eax58, edi11);
            //        v63 = al105;
            //    }
            //    addr_461138_30:
            //eax106 = _get_item_data(v41);
            //if (v63) {
            //    *reinterpret_cast<unsigned char*>(esi12 + 0x6f4) = reinterpret_cast<unsigned char>(* reinterpret_cast<unsigned char*>(esi12 + 0x6f4) & 0xfbff);
            //    *reinterpret_cast<unsigned char*>(esi12 + 0x7c8) = reinterpret_cast<unsigned char>(* reinterpret_cast<unsigned char*>(esi12 + 0x7c8) & 0xfeff);
            //    edx107 = _usrnum;
            //    v108 = (edx107);
            //    _deduct_item_charge(v41, v108, eax106, (uint)(ebp4) + 0xfffffff8);
            //    goto addr_461269_40;
            //}
            //addr_460f8f_27:
            //_terminate_multiple_matches(ecx53, 0);
            //eax37 = (1);
            //goto addr_46126c_10;

        }

        public void _cmd_whisper()
        {

            //TODO: Insert Logic.
        }

        public void _cmd_withdraw()
        {

            //TODO: Insert Logic.
        }

        public void _commands_pending()
        {

            //TODO: Insert Logic.
        }

        public void _commit_suicide()
        {

            //TODO: Insert Logic.
        }

        public void _compute_energy_used()
        {

            //TODO: Insert Logic.
        }

        public void _confirm_monster_in_room()
        {

            //TODO: Insert Logic.
        }

        public ulong _convert_currency(int runic, int platinum, int gold, int silver, int copper)
        {
            ulong tmpCopper;
            int tmpSilver;
            int tmpGold;
            int tmpPlatinum;

            int totalRunic;
            int totalPlatinum;
            int totalGold;
            int totalSilver;

            tmpCopper = (ulong)copper;
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

            if ((tmpCopper) <= ((ulong)(totalSilver) + (tmpCopper)))
            {
                tmpCopper = ((tmpCopper) + (ulong)(totalSilver));
            }

            return tmpCopper;
        }

        public void _count_valid_targets()
        {

            //TODO: Insert Logic.
        }

        public PlayerType _create_player(string username)
        {
            PlayerType player = ContentManager.Select<PlayerManager>().Select(username);

            if (player.GetUsername().Length == 0)
            {
                player.SetUserName(username);
                player.SetFirstName(username);

                player.Race = 0;
                player.Class = 0;
                player.Level = 1;
                player.NotExperience = 0;
                player.CPRemaining = 100;
                player.Intellect = 5;
                player.WillPower = 5;
                player.Strength = 5;
                player.Health = 5;
                player.Agility = 5;
                player.Charm = 5;
                player.MaxIntellect = 5;
                player.MaxWillPower = 5;
                player.MaxStrength = 5;
                player.MaxHealth = 5;
                player.MaxAgility = 5;
                player.MaxCharm = 5;
                player.MaximumHitpoints = 10;
                player.CurrentHitpoints = 10;
                player.WeaponHand = 0;
                player.Runic = 0;
                player.Platinum = 0;
                player.Gold = 0;
                player.Silver = 0;
                player.Copper = 0;
                player.MaximumEncumbrance = 0x1F4;
                player.CurrentEncumbrance = 0;

                player.Energy[0] = GameConstants.MAX_ENERGY_LEVEL;
                player.Energy[1] = GameConstants.MAX_ENERGY_LEVEL;
                player.Energy[2] = GameConstants.MAX_ENERGY_LEVEL;

                player.OffSet_xCC_xD7[0] = 0x7D;
                player.OffSet_xCC_xD7[1] = 0;
                player.MagicRes = 0;
                player.MagicRes2 = 0;
                player.MapNumber = 0x01;
                player.RoomNumber = 0x85C;
                // player.Nothing2 = 0;

                // player.Offset_6B8[2] = 0;

                // player.Unknown2[0] = GameConstants.MAX_ENERGY_LEVEL;
                // player.Unknown2[1] = GameConstants.MAX_ENERGY_LEVEL;

                // player.Nothing3 = 0;
                // player.Unknown3[0] = 0;
                // player.Unknown3[1] = 100;
                // player.unknown4[2] = 0;
                ////player.unknown4[4] = 0;
                // player.Offset_7C4[6] = 0;

                player.BillionsOfExperience = 0;
                player.MillionsOfExperience = 0;

                int tmpIndex = 0;

                do
                {
                    player.Item[tmpIndex] = 0;
                    ++tmpIndex;
                }
                while (tmpIndex < 100);

                tmpIndex = 0;

                do
                {
                    player.ItemUses[tmpIndex] = -1;
                    ++tmpIndex;
                }
                while (tmpIndex < 100);

                //TODO: Figure out what nothing5 is, maxnumber of keys?
                //player.Offset_330 = 50;

                tmpIndex = 0;

                do
                {
                    player.Key[tmpIndex] = 0;
                    player.KeyUses[tmpIndex] = -2;
                    ++tmpIndex;
                }
                while (tmpIndex < 50);

                player.MaximumKnownSpells = 100;

                tmpIndex = 0;

                do
                {
                    player.Spell[tmpIndex] = 0;
                    ++tmpIndex;
                }
                while (tmpIndex < 100);

                tmpIndex = 0;

                //TODO: figure what this offset is for?
                do
                {
                    //   player.Offset_544[tmpIndex] = 0;
                    tmpIndex++;
                }
                while (tmpIndex < 6);


                tmpIndex = 0;

                // Reset the last map / room of the player.
                do
                {
                    player.LastMap[tmpIndex] = 0;
                    player.LastRoom[tmpIndex] = 0;
                    ++tmpIndex;
                }
                while (tmpIndex < 20);

                player.BroadcastChannel = 0;
                player.BriefVerboseFlag = 1;
                player.TalkSpeed = 1;
                player.Statline = 2;

                //player.Offset_5F6 = 0;
                player.Perception = 0;
                player.Stealth = 0;
                player.MartialArts = 0;
                player.Thievery = 0;
                player.MaxMana = 0;
                player.CurrentMana = 0;
                player.SpellCasting = 0;
                player.Traps = 0;
                // player.Offset_608 = 0;
                player.Picklocks = 0;
                player.Tracking = 0;

                tmpIndex = 0;

                do
                {
                    player.WornItem[tmpIndex] = 0;
                    player.WornItemUses[tmpIndex] = -1;
                    ++tmpIndex;
                }
                while (tmpIndex < 20);

                // player.Offset_6A4 = 1;
                player.LivesRemaining = 9;
                //player.Offset_6player = 0;
                //player.Offset_6AA = 0xFFFF;
                //player.Offset_6AC = 0;

                tmpIndex = 0;

                do
                {
                    player.PartyMember[tmpIndex] = -1;
                    ++tmpIndex;
                }
                while (tmpIndex < 5);

                tmpIndex = 0;

                do
                {
                    player.SpellCasted[tmpIndex] = 0;
                    player.SpellValue[tmpIndex] = 0;
                    player.SpellRoundsLeft[tmpIndex] = 0;
                    ++tmpIndex;
                }
                while (tmpIndex < 10);

                //player.Offset_6B8[0] = 0;
                //player.Offset_6B8[1] = -1;
                //player.Offset_6EC[4] = 0;
                //player.Offset_7C4[2] = 0;
                //player.Offset_6EC[5] = -1;
                //player.Offset_6DC[5] = 1;
                player.EditFlag = 0;
                //player.Offset_6FD = 0;
                //player.Offset_6FE[0] = 0;

                //0x700
                //player.Offset_6FE[1] = 16 | 0x400;
                //player.Offset_6FE[2] = 0x03;
                //player.Offset_6FE[2] = 0x03 << 8 | 0x03;
                //player.Offset_6FE[3] = 0;
                //player.Offset_6FE[0] = 3;

                player.SetTitle("Apprentice");


                //ecx33 = reinterpret_cast < unsigned char> (esi12) << 3;
                //eax34 = g479104;
                //*reinterpret_cast<void***>(eax34 + (ecx33 + ecx33 * 2) * 8) = reinterpret_cast<void**>(0);
                //ecx35 = reinterpret_cast < unsigned char> (esi12) << 3;
                //eax36 = g479104;
                //*reinterpret_cast<int32_t*>(reinterpret_cast<uint32_t>(eax36 + (ecx35 + ecx35 * 2) * 8) + 4) = 0;
                //ecx37 = reinterpret_cast < unsigned char> (esi12) << 3;
                //eax38 = g479104;
                //*reinterpret_cast<int32_t*>(reinterpret_cast<uint32_t>(eax38 + (ecx37 + ecx37 * 2) * 8) + 8) = 0;
                //ecx39 = reinterpret_cast<void***>(reinterpret_cast < unsigned char > (esi12) << 3);
                //ecx40 = reinterpret_cast<void**>(ecx39 + reinterpret_cast<uint32_t>(ecx39) * 2);
                //eax41 = g479104;
                //*reinterpret_cast<int32_t*>(reinterpret_cast<uint32_t>(eax41 + reinterpret_cast < unsigned char > (ecx40) * 8) + 0x9c) = 0;

                short tmpEvilPoints = _get_saved_evil_points(username);

                player.EvilPoints = tmpEvilPoints;
                // player.unknown12e[11] = 22;

                tmpIndex = 0;

                do
                {
                    player.AbilityId[tmpIndex] = (short)tmpIndex;
                    player.AbilityValue[tmpIndex] = (short)(tmpIndex + 1);
                    ++tmpIndex;
                }
                while (tmpIndex < 30);


                player.CharacterLife = 0;

                //*reinterpret_cast<void***>(ebx14 + 0x724) = reinterpret_cast<void**>(0);
                //*reinterpret_cast<void***>(ebx14 + 0x7c0) = reinterpret_cast<void**>(0);
                //*reinterpret_cast<void***>(ebx14 + 0x7dc) = reinterpret_cast<void**>(0);
                //*reinterpret_cast < unsigned char*> (ebx14 + 0x7c4) = 0;
                //eax44 = fun_478c4c(0, v10, v8, v6);
                //*reinterpret_cast<uint16_t*>(ebx14 + 0x7c6) = *reinterpret_cast<uint16_t*>(&eax44);
                //eax15 = _update_user_with_permanent_info(0, ebx14);
                //*reinterpret_cast < unsigned char*> (ebx14 + 0x7d4) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (ebx14 + 0x7d4) | 0x80);
                //*reinterpret_cast < unsigned char*> (ebx14 + 0x7d4) = reinterpret_cast < unsigned char> (*reinterpret_cast < unsigned char*> (ebx14 + 0x7d4) | 0x2000);
            }

            return player;
        }
        public void _decrement_evil_timers()
        {

            //TODO: Insert Logic.
        }

        public void _deduct_currency()
        {

            //TODO: Insert Logic.
        }

        public void _deduct_exempt_credits()
        {

            //TODO: Insert Logic.
        }

        public void _deduct_item_charge()
        {

            //TODO: Insert Logic.
        }

        /// <summary>
        /// _delay_done is used to check if there delays added to the used has elapsed.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool _delay_done(PlayerType player)
        {
            return player.Delay == 0;
        }

        public void _delete_evil_points()
        {

            //TODO: Insert Logic.
        }

        public void _delete_monster()
        {

            //TODO: Insert Logic.
        }

        public void _delete_offline_mmud_user(PlayerType player)
        {

            //_delete_evil_points(player);
            //_delete_users_bankbooks(player);

            //int ebx10 = 0;
            //do
            //{
            //    if (*reinterpret_cast<int32_t*>(uint(esi5 + ebx10 * 4) + 0xd8))
            //    {
            //        v11 = (uint(esi5 + ebx10 * 4) + 0xd8);
            //        _remove_item_from_inventory(ecx7, 0xff, v11, (uint)(ebp3) + 0xfffffffc, esi5);
            //    }
            //    ++ebx10;
            //} while (ebx10 < 100);

            //do
            //{
            //    if (*reinterpret_cast<int32_t*>(uint(esi5 + ebx12 * 4) + 0x334))
            //    {
            //        v13 = (uint(esi5 + ebx12 * 4) + 0x334);
            //        _remove_item_from_inventory(ecx7, 0xff, v13, (uint)(ebp3) + 0xfffffffc, esi5);
            //    }
            //    ++ebx12;
            //}
            //while (ebx12 < 50);

            //eax15 = _get_gang_data(ecx14, ecx14);

            ContentManager.Select<PlayerManager>().Delete(player);
        }

        public void _delete_permanent_info()
        {

            //TODO: Insert Logic.
        }

        public void _delete_player()
        {

            //TODO: Insert Logic.
        }

        public void _delete_users_bankbooks()
        {

            //TODO: Insert Logic.
        }

        public void _deposit_gangleaders_account()
        {

            //TODO: Insert Logic.
        }

        public void _deposit_gold()
        {

            //TODO: Insert Logic.
        }

        public void _dir_monster_travelling_coord()
        {

            //TODO: Insert Logic.
        }

        public void _dir_player_travelling_coord()
        {

            //TODO: Insert Logic.
        }

        public void _direction_player_travelling()
        {

            //TODO: Insert Logic.
        }

        public void _dismiss_users_angels()
        {

            //TODO: Insert Logic.
        }

        public void _display_LONG_room_desc()
        {

            //TODO: Insert Logic.
        }

        public void _display_LONG_text()
        {

            //TODO: Insert Logic.
        }

        public void _display_LONG_text_to_room()
        {

            //TODO: Insert Logic.
        }

        public void _display_a_top_gang()
        {

            //TODO: Insert Logic.
        }

        public void _display_all_restocking_required()
        {

            //TODO: Insert Logic.
        }

        public void _display_attack_values()
        {

            //TODO: Insert Logic.
        }

        public void _display_autocombat_broken()
        {

            //TODO: Insert Logic.
        }

        public void _display_bank_balance()
        {

            //TODO: Insert Logic.
        }

        public void _display_buffer_statistics()
        {

            //TODO: Insert Logic.
        }

        public void _display_class_list()
        {

            //TODO: Insert Logic.
        }

        public void _display_coin_description()
        {

            //TODO: Insert Logic.
        }

        public void _display_conversion_rates()
        {

            //TODO: Insert Logic.
        }

        public void _display_debug_room_stats()
        {

            //TODO: Insert Logic.
        }

        public void _display_desc_from_file()
        {

            //TODO: Insert Logic.
        }

        public void _display_entry_movement()
        {

            //TODO: Insert Logic.
        }


        //signed char _display_evil_star(void** ecx, void** a2, void** a3, void** a4, void** a5)
        //{
        //    void** ecx6;
        //    void** edx7;
        //    void** eax8;

        //    ecx6 = a3;
        //    edx7 = a2;
        //    eax8 = g488180;
        //    if (!eax8)
        //    {
        //        return 1;
        //    }
        //    if (!eax8)
        //    {
        //        addr_44e90b_4:
        //        return 1;
        //    }
        //    else
        //    {
        //        do
        //        {
        //            if (ecx6 != *reinterpret_cast<void***>(eax8 + 4))
        //                continue;
        //            if (edx7 != *reinterpret_cast<void***>(eax8))
        //                continue;
        //            if (reinterpret_cast < unsigned char> (*reinterpret_cast<void***>(eax8 + 16)) & 2) 
        //        break;
        //            eax8 = *reinterpret_cast<void***>(eax8 + 20);
        //        } while (eax8);
        //        goto addr_44e90b_4;
        //    }
        //    return 0;
        //}

        public bool _display_evil_star(PlayerType player)
        {
            //object ecx6;
            //object edx7;
            //object eax8;

            int ecx6 = 0;
            int edx7 = 0;
            int eax8 = 0;

            //if (!eax8)
            //{
            //    return true;
            //}

            do
            {
                if (ecx6 != (eax8 + 4))
                    continue;
                if (edx7 != (eax8))
                    continue;
                if (((eax8 + 16) & 2) == 0x01)
                    break;
                eax8 = (eax8 + 20);
            }
            while (eax8 != 0);

            return true;
        }

        public void _display_evil_timers()
        {

            //TODO: Insert Logic.
        }

        public void _display_gang_members()
        {

            //TODO: Insert Logic.
        }

        public string FormatMessage(string message, params object[] parameters)
        {
            return string.Format(message, parameters);
        }

        // Used for debugging.
        public void _display_hidden_exit_status(PlayerType player, int parameter)
        {
            if ((parameter & 1) != 0)
            {
                FormatMessage("FLAG_PASSABLE {0}", parameter);
            }

            if ((parameter & 2) != 0)
            {
                FormatMessage("FLAG_NEED_SEARCH {0}", parameter);
            }

            //if (parameter & 4) {
            //    fun_478c28("FLAG_VISIBLE_SEARCHED ", esi3, ebx4, ebp5);
            //}
            //if (parameter & 8) {
            //    fun_478c28("FLAG_VISIBLE_BLOCKED ", esi3, ebx4, ebp5, "FLAG_VISIBLE_BLOCKED ", esi3, ebx4, ebp5);
            //}
            //if (parameter & 16) {
            //    fun_478c28("FLAG_BLOCKED_1 ", esi3, ebx4, ebp5, "FLAG_BLOCKED_1 ", esi3, ebx4, ebp5);
            //}
            //if (parameter & 32) {
            //    fun_478c28("FLAG_BLOCKED_2 ", esi3, ebx4, ebp5);
            //}
            //if (parameter & 64) {
            //    fun_478c28("FLAG_BLOCKED_3 ", esi3, ebx4, ebp5, "FLAG_BLOCKED_3 ", esi3, ebx4, ebp5);
            //}
            //if (parameter & 0x80) {
            //    fun_478c28("FLAG_BLOCKED_4 ", esi3, ebx4, ebp5, "FLAG_BLOCKED_4 ", esi3, ebx4, ebp5);
            //}

            //if (((parameter + 1) & 1) != 0)
            //{
            //    fun_478c28("FLAG_BLOCKED_5 ", esi3, ebx4, ebp5);
            //}

            //if (parameter + 1) &2) {
            //    fun_478c28("FLAG_BLOCKED_6 ", esi3, ebx4, ebp5, "FLAG_BLOCKED_6 ", esi3, ebx4, ebp5);
            //}
            //if (parameter + 1) &4) {
            //    fun_478c28("FLAG_BLOCKED_7 ", esi3, ebx4, ebp5, "FLAG_BLOCKED_7 ", esi3, ebx4, ebp5);
            //}
            //if (parameter + 1) &8) {
            //    fun_478c28("FLAG_BLOCKED_8 ", esi3, ebx4, ebp5);
            //}
            //if (parameter + 1) &16) {
            //    fun_478c28("FLAG_BLOCKED_9 ", esi3, ebx4, ebp5, "FLAG_BLOCKED_9 ", esi3, ebx4, ebp5);
            //}
            //if (parameter + 1) &32) {
            //    fun_478c28("FLAG_BLOCKED_10 ", esi3, ebx4, ebp5, "FLAG_BLOCKED_10 ", esi3, ebx4, ebp5);
            //}

            //LogManager.Log("\n", esi3, ebx4, ebp5);

            _tell_user("\n", player, player);
            //return eax8;
        }

        public void _display_inventory_items()
        {

            //TODO: Insert Logic.
        }

        public void _display_item_desc()
        {

            //TODO: Insert Logic.
        }

        public void _display_item_in_shop()
        {

            //TODO: Insert Logic.
        }

        public void _display_items_in_room()
        {

            //TODO: Insert Logic.
        }

        public void _display_list_of_actions()
        {

            //TODO: Insert Logic.
        }

        public void _display_list_of_all_active_monsters()
        {

            //TODO: Insert Logic.
        }

        public void _display_list_of_all_items()
        {

            //TODO: Insert Logic.
        }

        public void _display_list_of_all_known_monsters()
        {

            //TODO: Insert Logic.
        }

        public void _display_list_of_all_spells()
        {

            //TODO: Insert Logic.
        }

        public void _display_list_of_limited_items()
        {

            //TODO: Insert Logic.
        }

        public void _display_monster_desc()
        {

            //TODO: Insert Logic.
        }

        public void _display_movement()
        {

            //TODO: Insert Logic.
        }

        public void _display_new_list_of_limited_items()
        {

            //TODO: Insert Logic.
        }

        public void _display_next_reported_user()
        {

            //TODO: Insert Logic.
        }

        public void _display_next_topten()
        {

            //TODO: Insert Logic.
        }

        public void _display_next_topten_gang()
        {

            //TODO: Insert Logic.
        }

        public void _display_online_gang_members()
        {

            //TODO: Insert Logic.
        }

        public void _display_only_topten()
        {

            //TODO: Insert Logic.
        }

        public void _display_party()
        {

            //TODO: Insert Logic.
        }

        public void _display_profile()
        {

            //TODO: Insert Logic.
        }

        public void _display_protected_reason()
        {

            //TODO: Insert Logic.
        }

        public void _display_race_list()
        {

            //TODO: Insert Logic.
        }

        public void _display_recovery_mode_status()
        {

            //TODO: Insert Logic.
        }

        public void _display_room_desc()
        {

            //TODO: Insert Logic.
        }

        public void _display_scan_of_users()
        {

            //TODO: Insert Logic.
        }

        public void _display_shop_items()
        {

            //TODO: Insert Logic.
        }

        public void _display_spell_desc()
        {

            //TODO: Insert Logic.
        }

        public void _display_spell_success()
        {

            //TODO: Insert Logic.
        }

        public void _display_sysop_bulletin()
        {

            //TODO: Insert Logic.
        }

        public void _display_sysop_user_report()
        {

            //TODO: Insert Logic.
        }

        public void _display_top_gang_header()
        {

            //TODO: Insert Logic.
        }

        public void _display_top_gangs()
        {

            //TODO: Insert Logic.
        }

        public void _display_topten()
        {

            //TODO: Insert Logic.
        }

        public void _display_user_desc()
        {

            //TODO: Insert Logic.
        }

        public void _display_users_bankbooks()
        {

            //TODO: Insert Logic.
        }

        public void _display_users_hidden_in_room()
        {

            //TODO: Insert Logic.
        }

        public void _display_users_keys()
        {

            //TODO: Insert Logic.
        }

        public void _display_users_spells()
        {

            //TODO: Insert Logic.
        }

        public void _display_visible_exits()
        {

            //TODO: Insert Logic.
        }

        public void _dispose_of_item_in_room()
        {

            //TODO: Insert Logic.
        }

        public void _dispose_of_item_in_trail()
        {

            //TODO: Insert Logic.
        }

        public void _distribute_experience()
        {

            //TODO: Insert Logic.
        }

        public void _do_autocombat()
        {

            //TODO: Insert Logic.
        }

        public void _do_autocombat_for_user()
        {

            //TODO: Insert Logic.
        }

        public void _drag_user()
        {

            //TODO: Insert Logic.
        }

        public void LoadWCCTextMsg()
        {




        }

        public string _edit_character_stats(PlayerType player)
        {
            string outputMessage = string.Empty;

            outputMessage = PrintFormatUtility.sprintf("\r\n     M A J O R   M U D\r\n\r\n     Character Generator\r\n\r\n+-    Point Cost Chart    -+\r\n");
            outputMessage += PrintFormatUtility.sprintf("|                          |\r\n| 1st 10 points: 1 CP each |\r\n| 2nd 10 points: 2 CP each |\r\n");
            outputMessage += PrintFormatUtility.sprintf("| 3rd 10 points: 3 CP each |\r\n|     ... and so on ...    |\r\n|                          |\r\n");
            outputMessage += PrintFormatUtility.sprintf("| +10 to base stat:  10 CP |\r\n| +20 to base stat:  30 CP |\r\n| +30 to base stat:  60 CP |\r\n");
            outputMessage += PrintFormatUtility.sprintf("| +40 to base stat: 100 CP |\r\n| +50 to base stat: 150 CP |\r\n+-    ... and so on ...   -+\r\n\r\n");

            outputMessage += PrintFormatUtility.sprintf("Strength  %d - %d\r\n", player.Strength, player.MaxStrength);
            outputMessage += PrintFormatUtility.sprintf("Intellect %d - %d\r\n", player.Intellect, player.MaxIntellect);
            outputMessage += PrintFormatUtility.sprintf("Willpower %d - %d\r\n", player.WillPower, player.MaxWillPower);
            outputMessage += PrintFormatUtility.sprintf("Agility   %d - %d\r\n", player.Agility, player.MaxAgility);
            outputMessage += PrintFormatUtility.sprintf("Health    %d - %d\r\n", player.Health, player.MaxHealth);
            outputMessage += PrintFormatUtility.sprintf("Charm     %d - %d\r\n", player.Charm, player.MaxCharm);
            //v52 = (((ebx9 + 0x6fa)) - (((ebx9 + 0x6fa)) - ((((ebx9 + 0x6e2))))));
            outputMessage += PrintFormatUtility.sprintf("\r\nYou have %d CP to distribute.\r\n", 0);

            return outputMessage;
        }

        public void _edit_sysop_bulletin()
        {

            //TODO: Insert Logic.
        }

        public void _end_listing()
        {

            //TODO: Insert Logic.
        }

        public void _end_release_note_listing()
        {

            //TODO: Insert Logic.
        }

        public void _energy_update_character(PlayerType player)
        {
            //void** esi3;
            //void** ebx4;
            //void** ebp5;
            //void** eax6;
            //void** ecx7;
            //int32_t edx8;
            //void** eax9;

            //eax6 = _get_player(ecx, a2, esi3, ebx4, ebp5);
            //ecx7 = a2;
            if (PlayerType.Validate(player) == true)
            {
                //(eax6 + 0x6f4) = ((eax6 + 0x6f4) & 0xffbf);

                //if ((((eax6 + 0xba)) < ((eax6 + 0xb8)) ||
                // (edx8 = ((eax6 + 0x6f4)), !(((&edx8) + 1) & 2))) &&
                // ((ecx7 = (eax6 + 0xb8), (eax6 + 0xba) = (((eax6 + 0xba)) + (ecx7)), ((eax6 + 0xba)) > ((eax6 + 0xb8))) &&
                // (eax9 = _is_inside_autocombat(a2, esi3, ebx4), ecx7 = a2, !(&eax9))))
                //{
                //    (eax6 + 0xba) = (eax6 + 0xb8);
                //}

                //if (player.EncumbrancePercent > 66)
                //{
                //    (eax6 + 0x7c4) = 0;
                //}

                //eax6 = _validate_auto_combat(ecx7, a2, esi3);
            }
            //return eax6;
        }

        public void _energy_update_monster()
        {

            //TODO: Insert Logic.
        }

        public void _engage_autocombat()
        {

            //TODO: Insert Logic.
        }

        public void _equip_apply_item_abilities()
        {

            //TODO: Insert Logic.
        }

        public void _evil_for_robbing()
        {

            //TODO: Insert Logic.
        }

        public void _execute_input()
        {

            //TODO: Insert Logic.
        }

        public void _execute_pending_command()
        {

            //TODO: Insert Logic.
        }

        public void _fast_update_character()
        {

            //TODO: Insert Logic.
        }

        public void _fast_update_characters()
        {

            //TODO: Insert Logic.
        }

        public void _fast_update_monster()
        {

            //TODO: Insert Logic.
        }

        public void _fast_update_monsters()
        {

            //TODO: Insert Logic.
        }

        public void _fast_update_next_monster()
        {

            //TODO: Insert Logic.
        }

        public void _find_action_target()
        {

            //TODO: Insert Logic.
        }

        public void _find_any_action_target()
        {

            //TODO: Insert Logic.
        }


        public ItemType _find_item_in_inventory(PlayerType player, string searchFor)
        {
            ItemType itemType = new ItemType();

            int itemIndex = 0;

            while (itemIndex < 100)
            {
                if (player.Item[itemIndex] != 0)
                {

                    itemType = _get_item_data(player.Item[itemIndex]);

                    //                if (esi28)
                    //                {
                    //                    eax29 = _ljnsame(ecx23, a3, esi28 + 0xad);
                    //                    if (eax29)
                    //                    {
                    //                        v30 = 1;
                    //                        if (*reinterpret_cast < unsigned char*> ((uint)(&player) + 1) & 1 && *reinterpret_cast<uint16_t*>(esi28 + 0x2f4) != 4) {
                    //                            v30 = 0;
                    //                        }
                    //                        if (*reinterpret_cast < unsigned char*> ((uint)(&player) + 1) & 2 && *reinterpret_cast<uint16_t*>(esi28 + 0x2f4) != 5) {
                    //                            v30 = 0;
                    //                        }
                    //                        if (*reinterpret_cast < unsigned char*> ((uint)(&player) + 1) & 4 && *reinterpret_cast<uint16_t*>(esi28 + 0x2f4) != 6) {
                    //                            v30 = 0;
                    //                        }

                    //                        if (!(player) & 8)) {
                    //                            if (player) & 64) {
                    //                                eax31 = _usrnum;
                    //                                ecx32 = g479100;
                    //                                if ((ecx32 + uint((eax31) + reinterpret_cast < unsigned char > ((eax31)) * 4) * 4))
                    //                                {
                    //                                    fun_478c28("only worn, looking at: %s\r", esi28 + 0xad, v11, v9);
                    //                                    edx33 = _usrnum;
                    //                                    v34 = (edx33);
                    //                                    _tell_user(ecx32, v34);
                    //                                }
                    //                                v30 = 0;
                    //                                ecx23 = (0);
                    //                                v35 = (0);

                    //int wornIndex = 0;

                    //do
                    //{
                    //    if (player.WornItem[wornIndex] != 0)
                    //    {
                    //        if ((edx36 + uint((ecx23) + reinterpret_cast < unsigned char > ((ecx23)) * 4) * 4))
                    //        {
                    //            ecx37 = esi28 + 0xad;
                    //            fun_478c28("only worn, found %s at %d\r", ecx37, v35, v11);
                    //            eax38 = _usrnum;
                    //            v39 = (eax38);
                    //            _tell_user(ecx37, v39);
                    //            ecx23 = v39;
                    //        }
                    //        v30 = 1;
                    //    }
                    //    ++v35;
                    //} while (char(v35) < char(20));

                    //                                if (reinterpret_cast<int1_t>(static_cast<int32_t>(*reinterpret_cast < signed char *> (spell + 0x6ba)) == v25))
                    //                                {
                    //                                    ecx23 = _usrnum;
                    //                                    edx40 = g479100;
                    //                                    if ((edx40 + uint((ecx23) + reinterpret_cast < unsigned char > ((ecx23)) * 4) * 4))
                    //                                    {
                    //                                        ecx41 = esi28 + 0xad;
                    //                                        fun_478c28("only worn, found %s as a light source\r", ecx41, v11, v9);
                    //                                        eax42 = _usrnum;
                    //                                        v43 = (eax42);
                    //                                        _tell_user(ecx41, v43);
                    //                                        ecx23 = v43;
                    //                                    }
                    //                                    v30 = 1;
                    //                                }
                    //                                if ((spell + 0x624) == (esi28))
                    //                                {
                    //                                    ecx23 = _usrnum;
                    //                                    edx44 = g479100;
                    //                                    if ((edx44 + uint((ecx23) + reinterpret_cast < unsigned char > ((ecx23)) * 4) * 4))
                    //                                    {
                    //                                        ecx45 = esi28 + 0xad;
                    //                                        fun_478c28("only worn, found %s as a current weapon\r", ecx45, v11, v9);
                    //                                        eax46 = _usrnum;
                    //                                        v47 = (eax46);
                    //                                        _tell_user(ecx45, v47);
                    //                                        ecx23 = v47;
                    //                                    }
                    //                                    v30 = 1;
                    //                                }
                    //                            }
                    //                        } else {
                    //                            edx48 = _usrnum;
                    //                            eax49 = g479100;
                    //                            if ((eax49 + uint((edx48) + reinterpret_cast < unsigned char > ((edx48)) * 4) * 4))
                    //                            {
                    //                                fun_478c28("only unworn, looking at: %s\r", esi28 + 0xad, v11, v9);
                    //                                ecx50 = _usrnum;
                    //                                v51 = (ecx50);
                    //                                _tell_user(ecx50, v51);
                    //                            }
                    //                            v52 = 0;
                    //                            do
                    //                            {
                    //                                ecx23 = (uint(spell + v52 * 4) + 0x62c);
                    //                                if (ecx23 == (esi28))
                    //                                {
                    //                                    v30 = 0;
                    //                                }
                    //                                ++v52;
                    //                            } while (v52 < 20);
                    //                            if (reinterpret_cast<int1_t>(static_cast<int32_t>(*reinterpret_cast < signed char *> (spell + 0x6ba)) == v25))
                    //                            {
                    //                                edx53 = _usrnum;
                    //                                ecx23 = (edx53) + reinterpret_cast < unsigned char> ((edx53)) * 4;
                    //                                eax54 = g479100;
                    //                                if ((eax54 + reinterpret_cast < unsigned char> (ecx23) * 4)) {
                    //                                    fun_478c28("only unworn, found %s as a light source\r", esi28 + 0xad, v11, v9);
                    //                                    ecx55 = _usrnum;
                    //                                    v56 = (ecx55);
                    //                                    _tell_user(ecx55, v56);
                    //                                    ecx23 = v56;
                    //                                }
                    //                                v30 = 0;
                    //                            }
                    //                            if ((spell + 0x624) == (esi28))
                    //                            {
                    //                                edx57 = _usrnum;
                    //                                ecx23 = (edx57) + reinterpret_cast < unsigned char> ((edx57)) * 4;
                    //                                eax58 = g479100;
                    //                                if ((eax58 + reinterpret_cast < unsigned char> (ecx23) * 4)) {
                    //                                    fun_478c28("only unworn, found %s as a current weapon\r", esi28 + 0xad, v11, v9);
                    //                                    ecx59 = _usrnum;
                    //                                    v60 = (ecx59);
                    //                                    _tell_user(ecx59, v60);
                    //                                    ecx23 = v60;
                    //                                }
                    //                                v30 = 0;
                    //                            }
                    //                        }
                    //                        if (!v30)
                    //                        {
                    //                            ecx23 = _usrnum;
                    //                            edx61 = g479100;
                    //                            if ((edx61 + uint((ecx23) + reinterpret_cast < unsigned char > ((ecx23)) * 4) * 4))
                    //                            {
                    //                                if (!esi28)
                    //                                {
                    //                                    esi62 = ("unknown");
                    //                                }
                    //                                else
                    //                                {
                    //                                    esi62 = esi28 + 0xad;
                    //                                }
                    //                                fun_478c28("cannot use: %s\r", esi62, v11, v9);
                    //                                eax63 = _usrnum;
                    //                                v64 = (eax63);
                    //                                _tell_user(ecx23, v64);
                    //                                ecx23 = v64;
                    //                            }
                    //                        }
                    //                        else
                    //                        {
                    //                            if (v20 != (esi28))
                    //                            {
                    //                                v18 = 1;
                    //                                (a7) = (a7) + 1;
                    //                                ecx65 = v22 + 1;
                    //                                if ((a7) == ecx65)
                    //                                {
                    //                                    v20 = (esi28);
                    //                                    (a6) = v25;
                    //                                    ecx65 = a4;
                    //                                    (ecx65) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(spell + reinterpret_cast < unsigned char > (v25) * 2) + 0x268)));
                    //                                }
                    //                                v66 = esi28 + 0xad;
                    //                                _add_multiple_option(ecx65, v66);
                    //                                ecx23 = v66;
                    //                                eax67 = fun_478bb6(ecx23, a3, esi28 + 0xad);
                    //                                if (*reinterpret_cast<int16_t*>(&eax67))
                    //                                {
                    //                                    v20 = (esi28);
                    //                                    (a6) = v25;
                    //                                    ecx23 = v25;
                    //                                    (a4) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(spell + reinterpret_cast < unsigned char > (ecx23) * 2) + 0x268)));
                    //                                    v17 = 1;
                    //                                }
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    v68 = (uint(spell + reinterpret_cast < unsigned char > (v25) * 4) + 0xd8);
                    //                    eax69 = fun_478bf2(ecx23, "find_item: Item not found: %d", v68, a2, v11, v9);
                    //                    _internal_error(ecx23, eax69, a2);
                    //                    ecx23 = (0);
                    //                    (uint(spell + reinterpret_cast < unsigned char > (v25) * 4) + 0xd8) = (0);
                    //                }
                    //            }
                    //            ++v25;
                    //        }
                    //        if (!v18 && ((eax70 = fun_478ac6(ecx23), ecx23 = a3, ebx19 = eax70, !!ebx19) && ebx19 != a3))
                    //        {
                    //            (ebx19 + 0xffffffff) = (0);
                    //            ++v16;
                    //        }
                    //    } while (!v18 && (ebx19 != a3 && v24 < 50));
                    //    if (v17)
                    //        goto addr_46a620_64;
                    //    if ((a7) != v22 + 1)
                    //        goto addr_46a64a_66;
                    //    else
                    //        goto addr_46a620_64;
                    //}
                    //addr_46playerce_67:
                    //return eax21;
                    //addr_46a620_64:
                    //ebx71 = a3;
                    //(a5) = (1);
                    //while ((ebx71))
                    //{
                    //    ++ebx71;
                    //    edx72 = reinterpret_cast<void*>(0);
                    //    (&edx72) = (ebx71);
                    //    ecx73 = __ctype;
                    //    if (!(*reinterpret_cast < unsigned char*> (reinterpret_cast < unsigned char> (ecx73) + uint(edx72) + 1) &1)) 
                    //        continue;
                    //    (a5) = (a5) + 1;
                    //}
                    //addr_46a64a_66:
                    //ebx74 = a3;
                    //v75 = v16;
                    //if (v16)
                    //{
                    //    while (1)
                    //    {
                    //        if ((ebx74))
                    //        {
                    //            ++ebx74;
                    //        }
                    //        else
                    //        {
                    //            (ebx74) = (32);
                    //            --v16;
                    //            if (!v16)
                    //                break;
                    //        }
                    //    }
                    //}
                    //v76 = 0;
                    //if (!v17)
                    //{
                    //    if (*reinterpret_cast < unsigned char*> (spell + 0x330) > 50)
                    //    {
                    //        *reinterpret_cast < unsigned char*> (spell + 0x330) = 50;
                    //    }
                    //    v77 = 0;
                    //    do
                    //    {
                    //        ++v77;
                    //        ecx78 = (0);
                    //        v79 = (0);
                    //        while ((eax80 = (0), eax80) = *reinterpret_cast < unsigned char*> (spell + 0x330), char(eax80) > char(v79)) && !v17) {
                    //            if (*reinterpret_cast<int32_t*>(uint(spell + reinterpret_cast < unsigned char > (v79) * 4) + 0x334))
                    //            {
                    //                v81 = (uint(spell + reinterpret_cast < unsigned char > (v79) * 4) + 0x334);
                    //                eax82 = _get_item_data(v81, v81);
                    //                ecx78 = v81;
                    //                if (eax82)
                    //                {
                    //                    eax83 = _ljnsame(ecx78, a3, eax82 + 0xad);
                    //                    if (eax83 && v20 != (eax82))
                    //                    {
                    //                        v76 = 1;
                    //                        (a7) = (a7) + 1;
                    //                        ecx84 = v22 + 1;
                    //                        if ((a7) == ecx84)
                    //                        {
                    //                            v20 = (eax82);
                    //                            ecx84 = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(spell + reinterpret_cast < unsigned char > (v79) * 2) + 0x3fc)));
                    //                            (a4) = ecx84;
                    //                        }
                    //                        if (v16 < v75)
                    //                        {
                    //                            v75 = 0;
                    //                            (a7) = v22 + 1;
                    //                            v20 = (eax82);
                    //                            (a4) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(spell + reinterpret_cast < unsigned char > (v79) * 2) + 0x3fc)));
                    //                            _terminate_multiple_matches(a4, 1);
                    //                            ecx84 = (1);
                    //                        }
                    //                        v85 = eax82 + 0xad;
                    //                        _add_multiple_option(ecx84, v85);
                    //                        ecx78 = v85;
                    //                        eax86 = fun_478bb6(ecx78, a3, eax82 + 0xad);
                    //                        if (*reinterpret_cast<int16_t*>(&eax86))
                    //                        {
                    //                            v20 = (eax82);
                    //                            ecx78 = a4;
                    //                            (ecx78) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(spell + reinterpret_cast < unsigned char > (v79) * 2) + 0x3fc)));
                    //                            v17 = 1;
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    *reinterpret_cast<int32_t*>(uint(spell + reinterpret_cast < unsigned char > (v79) * 4) + 0x334) = 0;
                    //                    ecx78 = v79;
                    //                    *reinterpret_cast<int16_t*>(uint(spell + reinterpret_cast < unsigned char > (ecx78) * 2) + 0x3fc) = -2;
                    //                }
                    //            }
                    //            ++v79;
                    //        }
                    //        if (!v76)
                    //        {
                    //            if (v16 != v75)
                    //            {
                    //                eax87 = fun_478ac6(ecx78);
                    //                ebx74 = eax87;
                    //                if (ebx74 && ebx74 != a3)
                    //                {
                    //                    (ebx74 + 0xffffffff) = (0);
                    //                    ++v16;
                    //                }
                    //            }
                    //            else
                    //            {
                    //                v76 = 1;
                    //            }
                    //        }
                    //    } while (!v76 && (ebx74 != a3 && v77 < 50));
                    //    if (v17 || (a7) == v22 + 1)
                    //    {
                    //        ebx88 = a3;
                    //        (a5) = (1);
                    //        while ((ebx88))
                    //        {
                    //            ++ebx88;
                    //            edx89 = reinterpret_cast<void*>(0);
                    //            (&edx89) = (ebx88);
                    //            ecx90 = __ctype;
                    //            if (!(*reinterpret_cast < unsigned char*> (reinterpret_cast < unsigned char> (ecx90) + uint(edx89) + 1) &1)) 
                    //                continue;
                    //            (a5) = (a5) + 1;
                    //        }
                    //    }
                    //    ebx91 = a3;
                    //    if (v16)
                    //    {
                    //        while (1)
                    //        {
                    //            if ((ebx91))
                    //            {
                    //                ++ebx91;
                    //            }
                    //            else
                    //            {
                    //                (ebx91) = (32);
                    //                --v16;
                    //                if (!v16)
                    //                    break;
                    //            }
                    //        }
                }
            }

            return itemType;
        }

        public void _find_item_in_room()
        {

            //TODO: Insert Logic.
        }

        public void _find_monster_in_memory()
        {

            //TODO: Insert Logic.
        }

        public void _find_mud_action()
        {

            //TODO: Insert Logic.
        }

        public void _find_player()
        {

            //TODO: Insert Logic.
        }

        public void _find_spell_in_spellbook()
        {

            //TODO: Insert Logic.
        }

        public void _find_user_name()
        {

            //TODO: Insert Logic.
        }

        public void _free_spell_data()
        {

            //TODO: Insert Logic.
        }

        public void _generate_monster()
        {

            //TODO: Insert Logic.
        }

        public void _generate_top_list()
        {

            //TODO: Insert Logic.
        }

        public void _get_armour_rating()
        {

            //TODO: Insert Logic.
        }

        public void _get_bankbook_data()
        {

            //TODO: Insert Logic.
        }

        public ClassType _get_class_data(int classId)
        {
            return ContentManager.Select<ClassManager>().Select(classId);
        }

        public void _get_class_name()
        {

            //TODO: Insert Logic.
        }

        public int _get_coin_weight(PlayerType player)
        {
            int coinWeight = 0;

            if (player.AbilityId == null)
            {
                coinWeight = 0;
            }
            else
            {
                coinWeight = (player.Runic / 3 + player.Platinum / 3 +
                              player.Gold / 3 + player.Silver / 3 +
                              player.Copper / 3);
            }

            return coinWeight;
        }

        public void _get_component_string()
        {

            //TODO: Insert Logic.
        }

        public void _get_damage_descriptor(string inputStr)
        {

            //TODO: Insert Logic.
        }

        public int _get_encumbrance_percent(ref PlayerType player)
        {
            if (player.Username == null)
            {
                return 100;
            }
            else
            {
                // 1. Get the coin weight.
                int coinWeight = _get_coin_weight(player);

                // 2. result_one = coint weight + player + CurrentEncumberance * 100.
                int resultOne = coinWeight + player.CurrentEncumbrance * 100;

                // 3. get max weight.
                int maxWeight = _get_max_weight(player);

                // 4. result_two = result_one / max_weight.
                int resultTwo = resultOne / maxWeight;

                // 5. 0x708 = result_two.
                // return 0x708.
                player.EncumbrancePercent = (short)resultTwo;
            }

            return player.EncumbrancePercent;
        }

        public void _get_gang_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_hp_colour()
        {

            //TODO: Insert Logic.
        }

        public int _get_item_ability_value(ItemType item, int abilityId)
        {
            int abilityValue = 0;

            for (int i = 0; i < item.AbilityId.Length; i++)
            {
                if (item.AbilityId[i] == abilityId)
                {
                    abilityValue += item.AbilityValue[i];
                }
            }

            return abilityValue;
        }

        public ItemType _get_item_data(int itemId)
        {
            ItemType item = ContentManager.Select<ItemManager>().Select(itemId);

            if (item.Number <= 0)
            {
                _internal_error("Could not find item {0}.", itemId);
            }

            return item;
        }

        public void _get_item_from_name()
        {

            //TODO: Insert Logic.
        }

        public void _get_known_monster_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_last_active_monster_number()
        {

            //TODO: Insert Logic.
        }

        public void _get_last_item_number()
        {

            //TODO: Insert Logic.
        }

        public void _get_last_known_monster_number()
        {

            //TODO: Insert Logic.
        }

        public void _get_last_room_number()
        {

            //TODO: Insert Logic.
        }

        public void _get_last_spell_number()
        {

            //        ebp2 = reinterpret_cast<void*>(reinterpret_cast<int32_t>(__zero_stack_offset()) - 4);

            //        ebx3 = reinterpret_cast<void**>(0);

            //        v4 = g479130;
            //        fun_478ade(ecx);

            //        v5 = reinterpret_cast<void**>(reinterpret_cast<int32_t>(ebp2) + 0xfffffefc);

            //        ax6 = fun_478be0(v5, 0, 0, 13, 0, v5, 0, 0, 13, 0);

            //        if (ax6)
            //        {
            //            eax7 = fun_478c2e(v4, 0, 0);
            //            fun_478b6e(v4, reinterpret_cast<int32_t>(ebp2) + 0xfffffefc, eax7, 0, 0);
            //            ebx3 = reinterpret_cast<void**>(static_cast<uint32_t>(v8));
            //        }

            //        fun_478af0();

        }

        public int _get_legal_level(int evilPoint)
        {
            // Saint
            if ((evilPoint) >= (-201))
            {
                // Good
                if ((evilPoint) >= (-51))
                {
                    // Neutral
                    if ((evilPoint) >= (30))
                    {
                        // Seedy
                        if ((evilPoint) >= (40))
                        {
                            // Outlaw
                            if ((evilPoint) >= (80))
                            {
                                // Criminal
                                if ((evilPoint) >= (120))
                                {
                                    // Fiend
                                    if ((evilPoint) >= (210))
                                    {
                                        evilPoint = 5;
                                        return evilPoint;
                                    }
                                    else
                                    {
                                        evilPoint = 4;
                                        return evilPoint;
                                    }
                                }
                                else
                                {
                                    evilPoint = 3;
                                    return evilPoint;
                                }
                            }
                            else
                            {
                                evilPoint = 2;
                                return evilPoint;
                            }
                        }
                        else
                        {
                            evilPoint = 1;
                            return evilPoint;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    evilPoint = 6;
                    return evilPoint;
                }
            }
            else
            {
                evilPoint = 7;
                return evilPoint;
            }
        }

        public int _get_light_level(PlayerType player)
        {
            int lightLevel = 0;

            int mapId = player.MapNumber;
            int roomId = player.RoomNumber;

            RoomType room = _get_room_data(mapId, roomId);

            if (room.MapNumber > 0)
            {
                int roomLightLevel = room.Light;
                int playerLightLevel = _get_user_ability_value(player, AbilityTypes.Illuminate);

                int totalLightLevel = roomLightLevel + playerLightLevel;

            }

            return lightLevel;
        }

        public int _get_max_weight(PlayerType player)
        {
            int maxWeight = 0;

            int encumbranceModifier = _get_user_ability_value(player, AbilityTypes.Encumbrance);

            maxWeight = (encumbranceModifier + 100) * player.MaximumEncumbrance / 100;

            return maxWeight;
        }

        public MessageType _get_message_data(int messageId)
        {
            return ContentManager.Select<MessageManager>().Select(messageId);
        }

        public void _get_monster_ability_value(int npcId, int abilityId)
        {

        }

        public NonPlayerCharacterType _get_monster_data(int npcId)
        {
            return ContentManager.Select<NPCManager>().Select(npcId);
        }


        public void _get_mud_ini_value()
        {

            //TODO: Insert Logic.
            // Not used?
        }

        public void _get_my_attack_type()
        {


            //edx2 = 0;
            //return edx2 + (a1 + (a1) * 4) * 4) + 8;
        }

        public RaceType _get_race_data(int raceId)
        {
            return ContentManager.Select<RaceManager>().Select(raceId);
        }

        public string _get_race_name(int raceId)
        {
            return ContentManager.Select<RaceManager>().Select(raceId).GetName();
        }

        public void _get_random_name()
        {

            //TODO: Insert Logic.
        }

        public RoomType _get_room_data(int mapId, int roomId)
        {
            return ContentManager.Select<RoomManager>().Select(mapId, roomId);
        }

        public short _get_saved_evil_points(string username)
        {
            return 0;
        }

        public ShopType _get_shop_data(int shopId)
        {
            return ContentManager.Select<ShopManager>().Select(shopId);
        }

        public void _get_shop_item_from_name()
        {

            //TODO: Insert Logic.
        }

        /// <summary>
        /// Used to obtain the total value for an ability on the spell.
        /// </summary>
        /// <param name="spellId">The spelld id to look up.</param>
        /// <param name="abilityId">The ability id to tally up.</param>
        /// <returns>Total for a specific ability.</returns>
        public int _get_spell_ability_value(int spellId, int abilityId)
        {
            int abilityValue = 0;

            SpellType spell = _get_spell_data(spellId).Value;

            for (int i = 0; i < spell.AbilityId.Length; i++)
            {
                if (spell.AbilityId[i] == abilityId)
                {
                    abilityValue += spell.AbilityValue[i];
                }
            }

            return abilityValue;
        }

        public string _get_spell_from_name(int spellId)
        {
            return ContentManager.Select<SpellManager>().Select(spellId).GetName();
        }

        public void _get_spell_match_type()
        {

            //TODO: Insert Logic.
        }

        public void _get_spell_random_modifier()
        {

            //TODO: Insert Logic.
        }

        public void _get_text_block()
        {

            //TODO: Insert Logic.
        }

        public void _get_unique_active_monster_number()
        {

            //TODO: Insert Logic.
        }

        public int _get_user_ability_value(PlayerType player, int abilityId)
        {
            if (abilityId == AbilityTypes.Speed)
            {
                // TODO: Implement logic for "Speed" ability.
            }

            int totalValue = 0;

            // 1. Check Spell Data, check each spell slot for a spell.
            for (int i = 0; i < player.SpellCasted.Length; i++)
            {
                if (player.SpellCasted[i] > 0)
                {
                    SpellType spellType = _get_spell_data(player.SpellCasted[i]).Value;

                    for (int s = 0; s < spellType.AbilityId.Length; s++)
                    {
                        if (spellType.AbilityId[s] == abilityId)
                        {
                            totalValue += spellType.AbilityValue[s];
                        }
                    }
                }
            }


            // 2. Check Race Data, if there is no race ability, then
            RaceType raceType = _get_race_data(player.Race);

            for (int i = 0; i < raceType.AbilityId.Length; i++)
            {
                if (raceType.AbilityId[i] == abilityId)
                {
                    totalValue += raceType.AbilityValue[i];
                }
            }

            ClassType classType = _get_class_data(player.Class);

            // 2.a Check Class Data, TODO: the origal logic shows either race or class ability is checked, not both.
            for (int i = 0; i < classType.AbilityId.Length; i++)
            {
                if (classType.AbilityId[i] == abilityId)
                {
                    totalValue += classType.AbilityValue[i];
                }
            }

            // 3 Check player ability.
            for (int i = 0; i < player.AbilityId.Length; i++)
            {
                if (player.AbilityId[i] == abilityId)
                {
                    totalValue += player.AbilityValue[i];
                }
            }

            // 4. Check Player Worn Items
            for (int i = 0; i < player.WornItem.Length; i++)
            {
                if (player.WornItem[i] > 0)
                {
                    ItemType itemType = _get_item_data(player.WornItem[i]);

                    for (int s = 0; s < itemType.AbilityId.Length; s++)
                    {
                        if (itemType.AbilityId[s] == abilityId)
                        {
                            totalValue += itemType.AbilityValue[s];
                        }
                    }
                }
            }

            // 5. Check Player Main Hand. 
            if (player.WeaponHand > 0)
            {
                ItemType itemType = _get_item_data(player.WeaponHand);

                for (int i = 0; i < itemType.AbilityId.Length; i++)
                {
                    if (itemType.AbilityId[i] == abilityId)
                    {
                        totalValue += itemType.AbilityValue[i];
                    }
                }
            }

            return totalValue;
        }

        public int _get_user_ability_value(PlayerType player, int abilityId, int linkedMessage, out int messageId)
        {
            messageId = 0;

            if (abilityId == AbilityTypes.Speed)
            {
                // TODO: Implement logic for "Speed" ability.
            }

            int totalValue = 0;

            // 1. Check Spell Data, check each spell slot for a spell.
            for (int i = 0; i < player.SpellCasted.Length; i++)
            {
                if (player.SpellCasted[i] > 0)
                {
                    SpellType spellType = _get_spell_data(player.SpellCasted[i]).Value;

                    for (int s = 0; s < spellType.AbilityId.Length; s++)
                    {
                        if(spellType.AbilityId[s] == linkedMessage)
                        {
                            messageId = spellType.AbilityValue[s];
                        }

                        if (spellType.AbilityId[s] == abilityId)
                        {
                            totalValue += spellType.AbilityValue[s];
                        }
                    }
                }
            }


            // 2. Check Race Data, if there is no race ability, then
            RaceType raceType = _get_race_data(player.Race);

            for (int i = 0; i < raceType.AbilityId.Length; i++)
            {
                if (raceType.AbilityId[i] == abilityId)
                {
                    totalValue += raceType.AbilityValue[i];
                }
            }

            ClassType classType = _get_class_data(player.Class);

            // 2.a Check Class Data, TODO: the origal logic shows either race or class ability is checked, not both.
            for (int i = 0; i < classType.AbilityId.Length; i++)
            {
                if (classType.AbilityId[i] == abilityId)
                {
                    totalValue += classType.AbilityValue[i];
                }
            }

            // 3 Check player ability.
            for (int i = 0; i < player.AbilityId.Length; i++)
            {
                if (player.AbilityId[i] == abilityId)
                {
                    totalValue += player.AbilityValue[i];
                }
            }

            // 4. Check Player Worn Items
            for (int i = 0; i < player.WornItem.Length; i++)
            {
                if (player.WornItem[i] > 0)
                {
                    ItemType itemType = _get_item_data(player.WornItem[i]);

                    for (int s = 0; s < itemType.AbilityId.Length; s++)
                    {
                        if (itemType.AbilityId[s] == abilityId)
                        {
                            totalValue += itemType.AbilityValue[s];
                        }
                    }
                }
            }

            // 5. Check Player Main Hand. 
            if (player.WeaponHand > 0)
            {
                ItemType itemType = _get_item_data(player.WeaponHand);

                for (int i = 0; i < itemType.AbilityId.Length; i++)
                {
                    if (itemType.AbilityId[i] == abilityId)
                    {
                        totalValue += itemType.AbilityValue[i];
                    }
                }
            }

            return totalValue;
        }

        public ulong _get_user_currency(PlayerType player)
        {
            ulong totalCurrency = 0;

            totalCurrency = _convert_currency(player.Runic, player.Platinum, player.Gold,
                                              player.Silver, player.Copper);

            return totalCurrency;
        }

        public void _get_user_number()
        {

            //TODO: Insert Logic.
        }

        public object _get_user_number_from_id(object userId, object a2)
        {
            //object ebx4;
            //object esi6; 
            //object edi8;
            //object esi10;
            //int ebx11 = 0;
            //object eax12;
            //object eax13;
            //object eax14;
            //object eax15;
            //object npc;

            //esi10 = 0xffffffff;

            //if (a2 != null)
            //{
            //    ebx11 = 0;

            //    while ((eax12 = _nterms, (ebx11) < (eax12))) && esi10 == 0xffffffff)
            //   {
            //        eax13 = fun_46b93c(ecx, ebx11);

            //        ecx = ebx11;

            //        if ((&eax13) && ((eax14 = _get_player(userId), ecx = ebx11, !!eax14) &&
            //            (eax15 = fun_478bb6(ecx, edi9, eax14), !!*(&eax15))))
            //        {
            //            esi10 = ebx11;
            //        }

            //        ++ebx11;
            //    }
            //    npc = esi10;
            //}
            //else
            //{
            //    npc = (0xffffffff);
            //}

            //return npc;

            return 0;
        }

        public void _get_users_bankbook_balance()
        {

            //TODO: Insert Logic.
        }

        public void _give_monsters_a_free_attack()
        {

            //TODO: Insert Logic.
        }

        public void _h_ljnsame()
        {

            //TODO: Insert Logic.
        }

        public void _handle_CHAR_input()
        {

            //TODO: Insert Logic.
        }

        public void _handle_commands(string command)
        {

            //TODO: Insert Logic.
        }

        public void _handle_following_monsters()
        {

            //TODO: Insert Logic.
        }

        public void _handle_ljn_actions()
        {

            //TODO: Insert Logic.
        }

        public void _help_text()
        {

            //TODO: Insert Logic.
        }

        public void _init__wccmmud(string rootDirectory)
        {
            ContentManager.Initialize(rootDirectory);


        }

        public void _init_autocombat()
        {

            //TODO: Insert Logic.
        }

        public void _init_emulation()
        {

            //TODO: Insert Logic.
        }

        public void _initialize_ljngame_actions()
        {

            //TODO: Insert Logic.
        }

        public void _invalid_global()
        {

            //TODO: Insert Logic.
        }

        public void _invite_to_gang()
        {

            //TODO: Insert Logic.
        }

        public void _is_being_attacked()
        {

            //TODO: Insert Logic.
        }

        public void _is_combatting_monster()
        {

            //TODO: Insert Logic.
        }

        public void _is_combatting_user()
        {

            //TODO: Insert Logic.
        }

        public void _is_in_pvp_combat()
        {

            //TODO: Insert Logic.
        }

        public void _is_in_retaliation()
        {

            //TODO: Insert Logic.
        }

        public bool _is_inside_autocombat(PlayerType player)
        {

            //  do
            // {
            //   if (edx4 == playerIndexOffSet * 4 + 0x4969ec))
            //       break;
            //     ++eax5;
            //
            //  } while (eax5 < 0x226);

            return true;

        }

        public void _is_user_forgotten()
        {

            //TODO: Insert Logic.
        }

        public void _is_valid_monster_target()
        {

            //TODO: Insert Logic.
        }

        public void _is_valid_target()
        {

            //TODO: Insert Logic.
        }

        public void _is_weapon_too_fast_for_user()
        {

            //TODO: Insert Logic.
        }

        public bool _item_has_ability(int itemId, int abilityId)
        {
            ItemType item = _get_item_data(itemId);

            for (int i = 0; i < item.AbilityId.Length; i++)
            {
                if (item.AbilityId[i] == abilityId)
                {
                    return true;
                }
            }

            return false;
        }

        public void _item_is_in_stock()
        {

            //TODO: Insert Logic.
        }

        public void _join_gang()
        {

            //TODO: Insert Logic.
        }

        public void _kill_autocombat()
        {

            //TODO: Insert Logic.
        }

        public void _kill_autocombat_against()
        {

            //TODO: Insert Logic.
        }

        public void _kill_autocombat_against_monster()
        {

            //TODO: Insert Logic.
        }

        public void _ljndun()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_dlarou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_finrou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_huprou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_injrou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_lofrou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_lonrou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_mcurou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_stsrou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_sttrou()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_user_polling_routine()
        {

            //TODO: Insert Logic.
        }

        public void _ljngame_validate_name_polling()
        {

            //TODO: Insert Logic.
        }
        // //eax14 = _ljnsame(v13, a2, "Topics");
        public void _ljnsame(object a2, string searchFor)
        {
            //void** ebx4;
            //void** esi5;
            //void** eax6;
            //void** eax7;
            //void** edi8;
            //void** eax9;
            //void** eax10;
            //void** eax11;

            //ebx4 = a3;
            //esi5 = ebx4;

            //if (!a2 || !ebx4)
            //{
            //    eax6 = reinterpret_cast<void**>(0);
            //}
            //else
            //{
            //    eax7 = fun_478b3e(ecx, a2, ebx4);
            //    edi8 = reinterpret_cast<void**>(static_cast<int32_t>(*reinterpret_cast<int16_t*>(&eax7)));

            //    while (true)
            //    {
            //        eax9 = fun_478be6(ecx);
            //        ecx = ebx4;
            //        esi5 = eax9;

            //        if (!*reinterpret_cast<void***>(esi5))
            //            continue;

            //        eax10 = fun_478b08(ecx);
            //        ecx = esi5;
            //        ebx4 = eax10;
            //        if (!*reinterpret_cast<void***>(ebx4))
            //            continue;

            //        eax11 = fun_478b3e(ecx, a2, ebx4);
            //        edi8 = reinterpret_cast<void**>(static_cast<int32_t>(*reinterpret_cast<int16_t*>(&eax11)));
            //    }

            //    eax6 = edi8;
            //}

            //return eax6;

        }

        public void _ljnvfy()
        {

            //TODO: Insert Logic.
        }

        public void _load_bankbook_into_buffer()
        {

        }

        public void _load_class_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_gang_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_item_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_known_monster_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_message_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_monster_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_monster_quickreferences()
        {

            //TODO: Insert Logic.
        }

        public void _load_player()
        {

            //TODO: Insert Logic.
        }

        public void _load_race_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_room_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_shop_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _load_spell_into_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _majormud_send_mail()
        {

            //TODO: Insert Logic.
        }

        public void _majormud_syscyc()
        {

            //TODO: Insert Logic.
        }

        public void _match_combat_target()
        {

            //TODO: Insert Logic.
        }

        public void _match_string()
        {

            //TODO: Insert Logic.
        }

        public void _medium_update_character()
        {

            //TODO: Insert Logic.
        }

        public void _medium_update_characters()
        {

            //TODO: Insert Logic.
        }

        public void _medium_update_monster()
        {

            //TODO: Insert Logic.
        }

        public void _medium_update_monsters()
        {

            //TODO: Insert Logic.
        }

        public void _medium_update_next_monster()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_bankbook()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_class()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_gang()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_item()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_known_monster()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_message()
        {
            // TODO: This can be removed.
            //TODO: Insert Logic.
        }

        public void _mem_get_monster()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_race()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_room()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_shop()
        {

            //TODO: Insert Logic.
        }

        public void _mem_get_spell()
        {

            //TODO: Insert Logic.
        }

        public void _monster_add_cast_spell_to_user()
        {

            //TODO: Insert Logic.
        }

        public void _monster_add_duration_spell_to_room()
        {

            //TODO: Insert Logic.
        }

        public void _monster_cast()
        {

            //TODO: Insert Logic.
        }

        public void _monster_cast_area()
        {

            //TODO: Insert Logic.
        }

        public void _monster_could_attack()
        {

            //TODO: Insert Logic.
        }

        public void _monster_count_valid_targets()
        {

            //TODO: Insert Logic.
        }

        public void _monster_display_spell_success()
        {

            //TODO: Insert Logic.
        }

        public void _monster_has_ability()
        {

            //TODO: Insert Logic.
        }

        public void _monster_rob_user()
        {

            //TODO: Insert Logic.
        }

        public void _monster_update_room_users_stats()
        {

            //TODO: Insert Logic.
        }

        public void _move_monster()
        {

            //TODO: Insert Logic.
        }

        public void _move_monster_to_fighter()
        {

            //TODO: Insert Logic.
        }

        public void _move_player_to_fighter()
        {

            //TODO: Insert Logic.
        }

        public void _move_user()
        {

            //TODO: Insert Logic.
        }

        public void _my_rtkick()
        {

            //TODO: Insert Logic.
        }

        public void _negate_dynamic_with_ability()
        {

            //TODO: Insert Logic.
        }

        public void _new_calc_exp_needed()
        {

            //TODO: Insert Logic.
        }

        public void _one_time_class_change()
        {

            //TODO: Insert Logic.
        }

        public void _one_time_race_change()
        {

            //TODO: Insert Logic.
        }

        public void _parse_command()
        {

            //TODO: Insert Logic.
        }

        public void _parse_p_command()
        {

            //TODO: Insert Logic.
        }

        public void _parse_r_command()
        {

            //TODO: Insert Logic.
        }

        public void _parse_s_command()
        {

            //TODO: Insert Logic.
        }

        public void _parse_t_command()
        {

            //TODO: Insert Logic.
        }

        public void _parse_u_command()
        {

            //TODO: Insert Logic.
        }

        public void _parse_w_command()
        {

            //TODO: Insert Logic.
        }

        public void _perform_kicks()
        {

            //TODO: Insert Logic.
        }

        public void _perform_matched_action()
        {

            //TODO: Insert Logic.
        }

        public void _perform_random_event()
        {

            //TODO: Insert Logic.
        }

        public void _perform_routine_spell_monster_upkeep()
        {

            //TODO: Insert Logic.
        }

        public void _perform_routine_spell_player_upkeep()
        {

            //TODO: Insert Logic.
        }

        public void _perform_special_command()
        {

            //TODO: Insert Logic.
        }

        public void _perform_spell_termination_monster_upkeep()
        {

            //TODO: Insert Logic.
        }

        public void _perform_spell_termination_player_upkeep()
        {

            //TODO: Insert Logic.
        }

        public void _perform_text_block_as_special_command()
        {

            //TODO: Insert Logic.
        }

        public void _pick_valid_random_direction()
        {

            //TODO: Insert Logic.
        }

        public void _preload_and_generate_buffers()
        {

            //TODO: Insert Logic.
        }

        public void _prf_custom_statline()
        {

            //TODO: Insert Logic.
        }

        public void _prf_menu()
        {

            //TODO: Insert Logic.
        }

        public void _prf_prompt()
        {

            //TODO: Insert Logic.
        }

        public void _prf_wait_cycle()
        {

            //TODO: Insert Logic.
        }

        public void _printmap()
        {

            //TODO: Insert Logic.
        }

        public void _process_room()
        {

            //TODO: Insert Logic.
        }

        public void _proper_currency_name()
        {

            //TODO: Insert Logic.
        }

        public void _purge_spell_from_spellbook()
        {

            //TODO: Insert Logic.
        }

        public void _ready_weapon()
        {

            //TODO: Insert Logic.
        }

        public void _refresh_items_polling_routine()
        {

            //TODO: Insert Logic.
        }

        public void _refresh_search_active()
        {

            //TODO: Insert Logic.
        }

        public void _refresh_search_none()
        {

            //TODO: Insert Logic.
        }

        public void _refresh_search_rooms()
        {

            //TODO: Insert Logic.
        }

        public void _refresh_search_users()
        {

            //TODO: Insert Logic.
        }

        public void _register_mud_addon()
        {

            //TODO: Insert Logic.
        }

        public void _reinitialize_buffers()
        {

            //TODO: Insert Logic.
        }

        public void _reload__wccmmud()
        {

            //TODO: Insert Logic.
        }

        public void _remove_armour()
        {

            //TODO: Insert Logic.
        }

        public void _remove_from_gang()
        {

            //TODO: Insert Logic.
        }

        public void _remove_from_group()
        {

            //TODO: Insert Logic.
        }

        public void _remove_item_from_inventory()
        {

            //TODO: Insert Logic.
        }

        public void _remove_item_from_room()
        {

            //TODO: Insert Logic.
        }

        public void _remove_logical_from_monster()
        {

            //TODO: Insert Logic.
        }

        public void _remove_logical_from_room()
        {

            //TODO: Insert Logic.
        }

        public void _remove_logical_from_user()
        {

            //TODO: Insert Logic.
        }

        public void _remove_offline_user_from_gang()
        {

            //TODO: Insert Logic.
        }

        public void _remove_reroll()
        {

            //TODO: Insert Logic.
        }

        public void _remove_single_timer()
        {

            //TODO: Insert Logic.
        }

        public void _remove_users_bankbooks()
        {

            //TODO: Insert Logic.
        }

        public void _repay_gold()
        {

            //TODO: Insert Logic.
        }

        public void _reset_multiple_options()
        {

            //TODO: Insert Logic.
        }

        public void _restart_autocombat()
        {

            //TODO: Insert Logic.
        }

        public void _restock_items()
        {

            //TODO: Insert Logic.
        }

        public void _restructure_experience()
        {

            //TODO: Insert Logic.
        }

        public void _retrieve_public_userinfo()
        {

            //TODO: Insert Logic.
        }

        public void _retrieve_public_usrnum_userinfo()
        {

            //TODO: Insert Logic.
        }

        public void _rob_monster()
        {

            //TODO: Insert Logic.
        }

        public void _rob_user()
        {

            //TODO: Insert Logic.
        }

        public void _roll_stats()
        {

            //TODO: Insert Logic.
        }

        public void _room_cast_on_monster()
        {

            //TODO: Insert Logic.
        }

        public void _room_cast_on_user()
        {

            //TODO: Insert Logic.
        }

        public void _save_bankbook_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_buffers()
        {

            //TODO: Insert Logic.
        }

        public void _save_characters()
        {

            //TODO: Insert Logic.
        }

        public void _save_class_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_evil_points()
        {

            //TODO: Insert Logic.
        }

        public void _save_gang_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_item_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_known_monster_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_message_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_monster_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_next_buffer()
        {
            if (_nextBuffer >= 10)
            {
                _nextBuffer = 0;
            }

            switch (_nextBuffer)
            {
                case 0:
                    _save_room_from_buffer();
                    break;
                case 1:
                    _save_monster_from_buffer();
                    break;
                case 2:
                    _save_known_monster_from_buffer();
                    break;
                case 3:
                    _save_spell_from_buffer();
                    break;
                case 4:
                    _save_class_from_buffer();
                    break;
                case 5:
                    _save_race_from_buffer();
                    break;
                case 6:
                    _save_shop_from_buffer();
                    break;
                case 7:
                    _save_bankbook_from_buffer();
                    break;
                case 8:
                    _save_message_from_buffer();
                    break;
                case 9:
                    _save_gang_from_buffer();
                    break;
                case 10:
                    _save_item_from_buffer();
                    break;
            }

            _nextBuffer++;
        }

        public void _save_permanent_info()
        {

            //TODO: Insert Logic.
        }

        public void _save_race_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_room_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_shop_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _save_spell_from_buffer()
        {

            //TODO: Insert Logic.
        }

        public void _search_for_hidden_exits()
        {

            //TODO: Insert Logic.
        }

        public void _secret_visible_exit()
        {

            //TODO: Insert Logic.
        }

        public void _sell_item()
        {

            //TODO: Insert Logic.
        }

        public void _send_feedback_mail()
        {

            //TODO: Insert Logic.
        }

        public void _share_currency()
        {

            //TODO: Insert Logic.
        }

        public void _shop_sells_item()
        {

            //TODO: Insert Logic.
        }

        public void _should_give_evil()
        {

            //TODO: Insert Logic.
        }

        public void _show_current_emulations()
        {

            //TODO: Insert Logic.
        }

        public void _show_health()
        {

            //TODO: Insert Logic.
        }

        public void _show_status()
        {

            //TODO: Insert Logic.
        }

        public void _shuffle_mappings()
        {

            //TODO: Insert Logic.
        }

        public void _silly_spell()
        {

            //TODO: Insert Logic.
        }

        public void _slow_update_character()
        {

            //TODO: Insert Logic.
        }

        public void _slow_update_characters()
        {

            //TODO: Insert Logic.
        }

        public void _slow_update_monster()
        {

            //TODO: Insert Logic.
        }

        public void _slow_update_monsters()
        {

            //TODO: Insert Logic.
        }

        public void _slow_update_next_monster()
        {

            //TODO: Insert Logic.
        }

        public void _sneak()
        {

            //TODO: Insert Logic.
        }

        public void _sort_spell_list()
        {

            //TODO: Insert Logic.
        }

        public void _start_emulation()
        {

            //TODO: Insert Logic.
        }

        public void _stat_amount_used()
        {

            //TODO: Insert Logic.
        }

        public void _stop_dragging_user(PlayerType player)
        {

            if (PlayerType.Validate(player) == true && (player.CurrentHitpoints <= 0))
            {

                //while (eax13 = _nterms, ebx12 < (eax13))
                //{
                //    eax14 = fun_46b93c(ecx11, ebx12);
                //    ecx11 = ebx12;
                //    if ((&eax14) &&
                //     ((eax15 = _get_player(ecx11, ebx12, v7, v5, v3), ecx11 = ebx12, (bool)eax15) &&
                //      ((eax15 + 0x6f4) & 2 &&
                //       (esi9 == ((eax15 + 0x6f8))))))
                //    {
                //        (eax15 + 0x6f4) = (eax15 + 0x6f4) & 0xfffd;
                //        (eax15 + 0x6f8) = -1;
                //    }

                //    ++ebx12;
                //}
            }
            //return;
        }

        public void _stop_emulation()
        {

            //TODO: Insert Logic.
        }

        public void _stop_following()
        {

            //TODO: Insert Logic.
        }

        public void _stop_users_exit()
        {

            //TODO: Insert Logic.
        }

        public void _substitute_string()
        {

            //TODO: Insert Logic.
        }

        public void _sysop_bulletin_done()
        {

            //TODO: Insert Logic.
        }

        public void _take_monster_from_room()
        {

            //TODO: Insert Logic.
        }

        public void _tell_game(string message, int level)
        {

        }

        public void _tell_gang()
        {

            //TODO: Insert Logic.
        }

        public void _tell_group()
        {

            //TODO: Insert Logic.
        }

        public void _tell_room(string message, int mapId, int roomId)
        {
            LogManager.Log("_tell_room({0}/{1}): {2}", mapId, roomId, message);
        }

        public void _tell_user(string message, PlayerType fromPlayer, PlayerType toPlayer)
        {
            Console.WriteLine(message);
        }

        public void _terminate_multiple_matches()
        {

            //TODO: Insert Logic.
        }

        public void _track_monster()
        {

            //TODO: Insert Logic.
        }

        public void _track_player()
        {

            //TODO: Insert Logic.
        }

        public void _train_level()
        {

            //TODO: Insert Logic.
        }

        public void _unequip_apply_item_abilities()
        {

            //TODO: Insert Logic.
        }

        public void _update_allowed_worn_items()
        {

            //TODO: Insert Logic.
        }

        public void _update_dynamic_stats(PlayerType player)
        {

            //v3 = ebx4;
            //v5 = esi6;
            //v7 = edi8;
            //esi9 = a2;
            //v10 = 0;

            //if (!esi9)
            //{
            //    addr_43e3c5_2:
            //    return eax11;
            //}
            //else
            //{
            //    (esi9 + 0x6f4) = ((esi9 + 0x6f4) & 0xc67f);
            //    (esi9 + 0x7c8) = ((esi9 + 0x7c8) & 0xff59);
            //    (esi9 + 0x70a) = 0x8300;
            //    (esi9 + 0x70c) = 0;
            //    (esi9 + 0x70e) = 0;
            //    (esi9 + 0x7b4) = 0; // holds critical hit %
            //    (esi9 + 0x7b6) = 0;
            //    (esi9 + 0x7b8) = 0;
            //    (esi9 + 0x7ba) = 0;
            //    (esi9 + 0x7bc) = 0;
            //    (esi9 + 0x7be) = 0;
            //    (esi9 + 0x7d8) = 0;
            //    (esi9 + 0x7da) = 0;
            //    (esi9 + 0x6bc) = 0;
            //    ebx12 = 0;

            int abilityIndex = 0;

            do
            {
                if (player.AbilityId[abilityIndex] != 0)
                {
                    int currentValue = player.AbilityValue[abilityIndex];
                    int currentId = player.AbilityId[abilityIndex];

                    _update_dynamic_with_ability(player, currentId, currentValue);
                }

                ++abilityIndex;
            }
            while (abilityIndex < 30);

            //    ebx15 = 0;

            //    do
            //    {
            //        if (((esi9 + ebx15 * 2) + 64) && (v16 = ((((esi9 + ebx15 * 2) + 64))), eax17 = _get_spell_data(ecx, v16), ecx = v16, v18 = eax17, !!v18))
            //        {
            //            edi19 = 0;
            //            do
            //            {
            //                if (((v18 + edi19 * 2) + 0xd8))
            //                {
            //                    if (((v18 + edi19 * 2) + 0xd8) != 0x7c)
            //                    {
            //                        if (!((v18 + edi19 * 2) + 0xplayer))
            //                        {
            //                            v20 = ((((esi9 + ebx15 * 2) + 84)));
            //                            ecx = v18;
            //                            v21 = ((ecx + edi19 * 2) + 0xd8);
            //                            _update_dynamic_with_ability(ecx, esi9, v21, v20);
            //                        }
            //                        else
            //                        {
            //                            v22 = ((((v18 + edi19 * 2) + 0xplayer)));
            //                            ecx = v18;
            //                            v23 = ((ecx + edi19 * 2) + 0xd8);
            //                            _update_dynamic_with_ability(ecx, esi9, v23, v22);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        v10 = 1;
            //                    }
            //                }
            //                ++edi19;
            //            } while (edi19 < 10);
            //        }
            //        ++ebx15;
            //    } while (ebx15 < 10);

            //    v24 = (((esi9 + 0x90)));
            //    eax25 = _get_race_data(ecx, v24, v7, v5, v3);
            //    ecx26 = v24;
            //    edi27 = eax25;
            //    if (edi27)
            //        goto addr_43e1d1_19;
            //}

            //addr_43e1f6_20:
            //v28 = ((((esi9 + 0x92))));
            int classId = player.Class;
            ClassType classData = _get_class_data(classId);
            //ecx29 = v28;
            //edi30 = eax11;

            if (classData.Number != 0)
            {
                abilityIndex = 0;

                do
                {
                    if (classData.AbilityId[abilityIndex] != 0)
                    {
                        //v32 = ((((edi30 + ebx31 * 2) + 74)));// value
                        //v33 = ((edi30 + ebx31 * 2) + 44);// id

                        int classAbilityId = classData.AbilityId[abilityIndex];
                        int classAbilityValue = classData.AbilityValue[abilityIndex];


                        _update_dynamic_with_ability(player, classAbilityId, classAbilityValue);
                    }
                    ++abilityIndex;
                }
                while (abilityIndex < 10);
            }


            //ebx34 = 0;

            //do
            //{
            //    if (((esi9 + ebx34 * 4) + 0x62c) && (v35 = ((esi9 + ebx34 * 4) + 0x62c), eax11 = _get_item_data(v35, v35), ecx29 = v35, v36 = eax11, !!v36))
            //    {
            //        edi37 = 0;
            //        do
            //        {
            //            eax11 = v36;
            //            if (((eax11 + edi37 * 2) + 0x2f6))
            //            {
            //                ecx29 = ((((v36 + edi37 * 2) + 0x3e2)));
            //                v38 = ((v36 + edi37 * 2) + 0x2f6);
            //                eax11 = _update_dynamic_with_ability(ecx29, esi9, v38, ecx29);
            //            }
            //            ++edi37;
            //        } while (edi37 < 20);
            //    }
            //    ++ebx34;
            //} while (ebx34 < 20);

            //if ((esi9 + 0x624) && (v39 = (esi9 + 0x624), eax11 = _get_item_data(v39, v39), ecx29 = v39, v40 = eax11, !!v40))
            //{
            //    ebx41 = 0;
            //    do
            //    {
            //        eax11 = v40;
            //        if (((eax11 + ebx41 * 2) + 0x2f6))
            //        {
            //            ecx29 = ((((v40 + ebx41 * 2) + 0x3e2)));
            //            v42 = ((v40 + ebx41 * 2) + 0x2f6);
            //            eax11 = _update_dynamic_with_ability(ecx29, esi9, v42, ecx29);
            //        }
            //        ++ebx41;
            //    } while (ebx41 < 20);
            //}
            //ebx43 = 0;

            //do
            //{
            //    if (((esi9 + ebx43 * 4) + 0xd8) && ((v44 = ((esi9 + ebx43 * 4) + 0xd8), eax11 = _get_item_data(v44, v44), ecx29 = v44, v45 = eax11, !!v45) && ((eax11 = v45, (eax11 + 0x2f4) != 1) && !(v45 + 0x398))))
            //    {
            //        edi46 = 0;
            //        do
            //        {
            //            eax11 = v45;
            //            if (((eax11 + edi46 * 2) + 0x2f6))
            //            {
            //                ecx29 = ((((v45 + edi46 * 2) + 0x3e2)));
            //                v47 = ((v45 + edi46 * 2) + 0x2f6);
            //                eax11 = _update_dynamic_with_ability(ecx29, esi9, v47, ecx29);
            //            }
            //            ++edi46;
            //        } while (edi46 < 20);
            //    }
            //    ++ebx43;
            //} while (ebx43 < 100);

            //if (v10)
            //{
            //    ebx48 = 0;
            //    do
            //    {
            //        if (((esi9 + ebx48 * 2) + 64) && (v49 = ((((esi9 + ebx48 * 2) + 64))), eax11 = _get_spell_data(ecx29, v49), ecx29 = v49, v50 = eax11, !!v50))
            //        {
            //            edi51 = 0;
            //            do
            //            {
            //                eax11 = v50;
            //                if (((eax11 + edi51 * 2) + 0xd8) == 0x7c)
            //                {
            //                    ecx29 = ((((v50 + edi51 * 2) + 0xplayer)));
            //                    eax11 = _negate_dynamic_with_ability(esi9, ecx29);
            //                }
            //                ++edi51;
            //            } while (edi51 < 10);
            //        }
            //        ++ebx48;
            //    } while (ebx48 < 10);
            //}
            //if ((esi9 + 0x70a) == 0x8300)
            //{
            //    (esi9 + 0x70a) = 0;
            //    goto addr_43e3c5_2;
            //}
            //addr_43e1d1_19:
            //ebx52 = 0;
            //do
            //{
            //    if (((edi27 + ebx52 * 2) + 50))
            //    {
            //        v53 = ((((edi27 + ebx52 * 2) + 72)));
            //        v54 = ((edi27 + ebx52 * 2) + 50);
            //        _update_dynamic_with_ability(ecx26, esi9, v54, v53);
            //    }
            //    ++ebx52;
            //} while (ebx52 < 10)
        }

        public void _update_dynamic_with_ability(PlayerType player, int abilityId, int abilityValue)
        {
            // player = player
            // abilityId = ability id
            // abilityValue = ability value

            //if (abilityId > 68)
            //{
            //    if (abilityId <= 99)
            //    {
            //        // 99 = AlterDRPercent
            //        if (abilityId == 99)
            //        {
            //            player.OffSet_x7B2_x7BF[6] = (byte)(player.OffSet_x7B2_x7BF[6] + abilityValue);
            //            return;
            //        }

            //        int edx5 = abilityId & 0xffffffb9;

            //        if (edx5 > 16)
            //            goto addr_43de04_6;

            //        switch (edx5)
            //        {
            //            case 0:
            //                player + 0x6f4 = (player.OffSet_x6EC_x6FB[8] | 0x80);
            //                return player;
            //                addr_43de04_6:
            //            case 1:
            //            case 2:
            //            case 6:
            //            case 7:
            //            case 8:
            //            case 9:
            //            case 10:
            //            case 11:
            //            case 12:
            //            case 13:
            //            case 14:
            //            case 15:
            //                return player;
            //            case 3:
            //                player.OffSet_x7C4_x7D5[4] = (byte)(player.OffSet_x7C4_x7D5[4] | 32);
            //                break;
            //            case 4:
            //                (player + 0x6f4) = ((player + 0x6f4) | 0x800);
            //                return player;
            //            case 5:
            //                (player + 0x6f4) = ((player + 0x6f4) | 0x100);
            //                return player;
            //            case 16:
            //                if (!(player + 0x7ba))
            //                {
            //                    (player + 0x7ba) = (&abilityValue);
            //                    return player;
            //                }
            //                else
            //                {
            //                    edx6 = (((player + 0x7ba) + (abilityValue)) >> 1);
            //                    if (__undefined())
            //                    {
            //                        edx6 = edx6 + __intrinsic();
            //                    }
            //                  (player + 0x7ba) = (&edx6);
            //                    return player;
            //                }
            //        }
            //    }

            //    if ((abilityId) > (0x6b))
            //    {
            //        edx7 = abilityId - 0x7b;
            //        if (!edx7)
            //        {
            //            (player + 0x7d8) = ((player + 0x7d8) + (&abilityValue));
            //            return player;
            //        }
            //        else
            //        {
            //            if (!(edx7 - 22))
            //            {
            //                (player + 0x7da) = ((player + 0x7da) + (&abilityValue));
            //                return player;
            //            }
            //            else
            //            {
            //                goto addr_43de04_6;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (abilityId == 0x6b)
            //        {
            //            (player + 0x6f4) = ((player + 0x6f4) | 0x1000);
            //            return player;
            //        }
            //        edx8 = abilityId - 0x68;
            //        if (!edx8)
            //        {
            //            (player + 0x7be) = ((player + 0x7be) + (&abilityValue));
            //            return player;
            //        }
            //        if (edx8 - 1 >= 2)
            //            goto addr_43dcba_28;
            //    }
            //}
            //else
            //{
            //    if (abilityId == 68)
            //    {
            //        (player + 0x7c8) = ((player + 0x7c8) | 2);
            //        return player;
            //    }
            //    if ((abilityId) > (14))
            //        goto addr_43dc05_32;
            //    else
            //        goto addr_43dbc3_33;
            //}
            //addr_43dcd6_34:
            //if ((((player + 0x70a))) < (abilityValue))
            //{
            //    (player + 0x70a) = (&abilityValue);
            //    return player;
            //}
            //addr_43dcba_28:
            //goto addr_43de04_6;
            //addr_43dc05_32:

            //if ((abilityId) > (58))
            //{
            //    edx9 = abilityId - 60;
            //    if (!edx9)
            //    {
            //        (player + 0x7c8) = ((player + 0x7c8) | 0x80);
            //        return player;
            //    }
            //    else
            //    {
            //        if (!(edx9 - 7))
            //        {
            //            (player + 0x7c8) = ((player + 0x7c8) | 4);
            //            return player;
            //        }
            //        else
            //        {
            //            goto addr_43de04_6;
            //        }
            //    }
            //}

            //// crits
            //if (abilityId == 58)
            //{
            //    player.OffSet_x7B2_x7BF[2] = (byte)(player.OffSet_x7B2_x7BF[2] + abilityValue);
            //}

            //edx10 = abilityId - 22;
            //if (!edx10)
            //    goto addr_43dcd6_34;
            //if (!(edx10 - 35))
            //{
            //    (player + 0x6f4) = ((player + 0x6f4) | 0x2000);
            //    return player;
            //}
            //else
            //{
            //    goto addr_43de04_6;
            //}
            //addr_43dbc3_33:
            //// Light Level (Room Illumination
            //if (abilityId == 14)
            //{
            //    (player + 0x6bc) = ((player + 0x6bc) + (&abilityValue));
            //    goto addr_43de04_6;
            //}

            //if (abilityId > 10)
            //    goto addr_43de04_6;
            //goto (abilityId * 4 + 0x43dbd9);

            //(player + 0x70c) = ((player + 0x70c) + (&abilityValue));
            //return player;
            //(player + 0x70e) = ((player + 0x70e) + (&abilityValue));
            //return player;
            //(player + 0x7b6) = ((player + 0x7b6) + (&abilityValue));
            //return player;
            //(player + 0x7bc) = ((player + 0x7bc) + (&abilityValue));
            //return player;
        }

        public void _update_edit()
        {

            //TODO: Insert Logic.
        }

        public void _update_kai_powers()
        {

            //TODO: Insert Logic.
        }

        public void _update_polling_routine()
        {

            //TODO: Insert Logic.
        }

        public void _update_room_users_stats()
        {

            //TODO: Insert Logic.
        }

        public void _update_top_list()
        {

            //TODO: Insert Logic.
        }

        public void _update_user_with_permanent_info()
        {

            //TODO: Insert Logic.
        }

        public void _update_weight_carried()
        {

            //TODO: Insert Logic.
        }

        public void _use_item_target()
        {

            //TODO: Insert Logic.
        }

        public void _use_monster_target()
        {

            //TODO: Insert Logic.
        }

        public void _use_no_target()
        {

            //TODO: Insert Logic.
        }

        public void _use_player_target()
        {

            //TODO: Insert Logic.
        }

        public void _use_spell_target()
        {

            //TODO: Insert Logic.
        }

        public void _user_allowed_in_room()
        {

            //TODO: Insert Logic.
        }

        public void _user_being_dragged()
        {

            //TODO: Insert Logic.
        }

        public void _user_can_use()
        {

            //TODO: Insert Logic.
        }

        public void _user_can_use_spell()
        {

            //TODO: Insert Logic.
        }

        public bool _user_has_ability(PlayerType player, int abilityId)
        {
            // 1. Check Spell Data, check each spell slot for a spell.
            for (int i = 0; i < player.SpellCasted.Length; i++)
            {
                if (player.SpellCasted[i] > 0)
                {
                    SpellType spellType = _get_spell_data(player.SpellCasted[i]).Value;

                    for (int s = 0; s < spellType.AbilityId.Length; s++)
                    {
                        if (spellType.AbilityId[s] == abilityId)
                        {
                            return true;
                        }
                    }
                }
            }


            // 2. Check Race Data, if there is no race ability, then
            RaceType raceType = _get_race_data(player.Race);

            for (int i = 0; i < raceType.AbilityId.Length; i++)
            {
                if (raceType.AbilityId[i] == abilityId)
                {
                    return true;
                }
            }

            ClassType classType = _get_class_data(player.Class);

            // 2.a Check Class Data, TODO: the origal logic shows either race or class ability is checked, not both.
            for (int i = 0; i < classType.AbilityId.Length; i++)
            {
                if (classType.AbilityId[i] == abilityId)
                {
                    return true;
                }
            }

            // 3 Check player ability.
            for (int i = 0; i < player.AbilityId.Length; i++)
            {
                if (player.AbilityId[i] == abilityId)
                {
                    return true;
                }
            }

            // 4. Check Player Worn Items
            for (int i = 0; i < player.WornItem.Length; i++)
            {
                if (player.WornItem[i] > 0)
                {
                    ItemType itemType = _get_item_data(player.WornItem[i]);

                    for (int s = 0; s < itemType.AbilityId.Length; s++)
                    {
                        if (itemType.AbilityId[s] == abilityId)
                        {
                            return true;
                        }
                    }
                }
            }

            // 5. Check Player Main Hand. 
            if (player.WeaponHand > 0)
            {
                ItemType itemType = _get_item_data(player.WeaponHand);

                for (int i = 0; i < itemType.AbilityId.Length; i++)
                {
                    if (itemType.AbilityId[i] == abilityId)
                    {
                        return true;
                    }
                }
            }


            return false;
        }

        public void _user_is_wearing()
        {

            //TODO: Insert Logic.
        }

        public void _validate_auto_combat()
        {

            //TODO: Insert Logic.
        }

        public void _visible_exit()
        {

            //TODO: Insert Logic.
        }

        public void _wear_armour()
        {

            //TODO: Insert Logic.
        }

        public void _wildcard_match()
        {

            //TODO: Insert Logic.
        }

        public void _withdraw_gold()
        {

            //TODO: Insert Logic.
        }

        public void _xref_users_items_polling_routine()
        {

            //TODO: Insert Logic.
        }

        public void _xref_users_polling_routine()
        {

            //TODO: Insert Logic.
        }


    }
}
