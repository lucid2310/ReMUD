using ReMUD.Game.Btrieve;
using ReMUD.Game.Content;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.SupportTypes;
using ReMUD.Game.Structures.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ReMUD.Game
{
    /// <summary>
    /// The GameManager class will manage all the logic in the game currently.
    /// </summary>
    public class GameManager
    {
        public MetaContentManager ContentManager = new MetaContentManager();
        private int _nextBuffer = 0;
        
        public void _internal_error(string message, params object[] parameters)
        {
            LogManager.Log(message, parameters);
        }

        public void _log(string message, params object[] parameters)
        {
            LogManager.Log(message, parameters);
        }

        public PlayerType _get_player(int userId)
        {
            PlayerType playerInfo = new PlayerType();

            string errorMessage = string.Empty;

            if (ContentManager.UserContentManager.UserIdExists(userId) == false)
            {
                errorMessage = "get_player: {0} (user number: {1} [{2}])";

                _internal_error(errorMessage, userId, userId, ContentManager.UserContentManager.GetUsername(userId));
            }
            else
            {
                string username = ContentManager.UserContentManager.GetUsername(userId);

                playerInfo = ContentManager.Select<PlayerManager>().Select(username);            
            }

            return playerInfo;
        }

        public void _save_player(PlayerEntity playerInfo)
        {
            ushort saveStatus = 0;// GameContentManager.PlayerContentManager.Save(playerInfo);

            switch (saveStatus)
            {
                case BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY:
                    _log("Player {0} saved.", BtrieveUtility.ConvertToString(playerInfo.Record.Username));
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
            for(int i = 0; i < player.WornItem.Length; i++)
            {
                if(player.WornItem[i].Equals(itemId) == true)
                {
                    return true;
                }
            }

            return false;
        }

        public void _add_cast_spell_to_monster()
        {

            //TODO: Insert Logic.
        }

        public void _add_cast_spell_to_user()
        {

            //TODO: Insert Logic.
        }

        public void _add_delay(PlayerType player, byte delay)
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

        public void _add_evil_points()
        {

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
            bool status = _user_has_ability(player, AbilityTypes.FindTraps);

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

            if(lightLevel >= -149)
            {
                if(lightLevel <= 0x384)
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
            return string.Format(message, arguments);
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

        public void _cast_monster_target()
        {

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

        public void _check_confusion()
        {

            //TODO: Insert Logic.
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
    //                eax85 = _parse_command(ecx84, ecx84, v82);
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
                //player.Offset_6A8 = 0;
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

        public void _display_evil_star()
        {

            //TODO: Insert Logic.
        }

        public void _display_evil_timers()
        {

            //TODO: Insert Logic.
        }

        public void _display_gang_members()
        {

            //TODO: Insert Logic.
        }

        public void _display_hidden_exit_status()
        {

            //TODO: Insert Logic.
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


        public void _edit_character_stats()
        {

            TcpListener listener = new TcpListener(new System.Net.IPEndPoint(IPAddress.Any, 23));

            listener.Start(1);

            TcpClient client = listener.AcceptTcpClient();


            string fileContents = File.ReadAllText(@"C:\Projects\GIT\ReMUD\DATs\wcctext.msg", Encoding.GetEncoding(437));

            List<string> characterCreationMenu = new List<string>();
            List<TextMsgTypes> menus = new List<TextMsgTypes>();


            int startIndex = 0;
            int stopIndex = 0;
            
            for(int i = 0; i < fileContents.Length; i++)
            {
                
                if(fileContents[i] == '{')
                {
                    startIndex = i;
                }

                if(fileContents[i] == '}')
                {
                    stopIndex = i;
                    menus.Add(new TextMsgTypes(startIndex, stopIndex, fileContents));

                    startIndex = 0;
                    stopIndex = 0;

                    client.Client.Send(AnsiUtility.GetBytes(menus[menus.Count -1].TextMsg));
                    client.Client.Send(new byte[] { 0x0a, 0x0d});
                }
            }

            
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
                    //                        if (*reinterpret_cast < unsigned char*> ((uint)(&a8) + 1) & 1 && *reinterpret_cast<uint16_t*>(esi28 + 0x2f4) != 4) {
                    //                            v30 = 0;
                    //                        }
                    //                        if (*reinterpret_cast < unsigned char*> ((uint)(&a8) + 1) & 2 && *reinterpret_cast<uint16_t*>(esi28 + 0x2f4) != 5) {
                    //                            v30 = 0;
                    //                        }
                    //                        if (*reinterpret_cast < unsigned char*> ((uint)(&a8) + 1) & 4 && *reinterpret_cast<uint16_t*>(esi28 + 0x2f4) != 6) {
                    //                            v30 = 0;
                    //                        }

                    //                        if (!(*reinterpret_cast < unsigned char*> (&a8) & 8)) {
                    //                            if (*reinterpret_cast < unsigned char*> (&a8) & 64) {
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

                    //                                if (reinterpret_cast<int1_t>(static_cast<int32_t>(*reinterpret_cast < signed char *> (edi15 + 0x6ba)) == v25))
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
                    //                                if ((edi15 + 0x624) == (esi28))
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
                    //                                ecx23 = (uint(edi15 + v52 * 4) + 0x62c);
                    //                                if (ecx23 == (esi28))
                    //                                {
                    //                                    v30 = 0;
                    //                                }
                    //                                ++v52;
                    //                            } while (v52 < 20);
                    //                            if (reinterpret_cast<int1_t>(static_cast<int32_t>(*reinterpret_cast < signed char *> (edi15 + 0x6ba)) == v25))
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
                    //                            if ((edi15 + 0x624) == (esi28))
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
                    //                                    (ecx65) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(edi15 + reinterpret_cast < unsigned char > (v25) * 2) + 0x268)));
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
                    //                                    (a4) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(edi15 + reinterpret_cast < unsigned char > (ecx23) * 2) + 0x268)));
                    //                                    v17 = 1;
                    //                                }
                    //                            }
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    v68 = (uint(edi15 + reinterpret_cast < unsigned char > (v25) * 4) + 0xd8);
                    //                    eax69 = fun_478bf2(ecx23, "find_item: Item not found: %d", v68, a2, v11, v9);
                    //                    _internal_error(ecx23, eax69, a2);
                    //                    ecx23 = (0);
                    //                    (uint(edi15 + reinterpret_cast < unsigned char > (v25) * 4) + 0xd8) = (0);
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
                    //addr_46a8ce_67:
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
                    //    if (*reinterpret_cast < unsigned char*> (edi15 + 0x330) > 50)
                    //    {
                    //        *reinterpret_cast < unsigned char*> (edi15 + 0x330) = 50;
                    //    }
                    //    v77 = 0;
                    //    do
                    //    {
                    //        ++v77;
                    //        ecx78 = (0);
                    //        v79 = (0);
                    //        while ((eax80 = (0), *reinterpret_cast < unsigned char*> (&eax80) = *reinterpret_cast < unsigned char*> (edi15 + 0x330), char(eax80) > char(v79)) && !v17) {
                    //            if (*reinterpret_cast<int32_t*>(uint(edi15 + reinterpret_cast < unsigned char > (v79) * 4) + 0x334))
                    //            {
                    //                v81 = (uint(edi15 + reinterpret_cast < unsigned char > (v79) * 4) + 0x334);
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
                    //                            ecx84 = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(edi15 + reinterpret_cast < unsigned char > (v79) * 2) + 0x3fc)));
                    //                            (a4) = ecx84;
                    //                        }
                    //                        if (v16 < v75)
                    //                        {
                    //                            v75 = 0;
                    //                            (a7) = v22 + 1;
                    //                            v20 = (eax82);
                    //                            (a4) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(edi15 + reinterpret_cast < unsigned char > (v79) * 2) + 0x3fc)));
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
                    //                            (ecx78) = (static_cast<int32_t>(*reinterpret_cast<int16_t*>(uint(edi15 + reinterpret_cast < unsigned char > (v79) * 2) + 0x3fc)));
                    //                            v17 = 1;
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    *reinterpret_cast<int32_t*>(uint(edi15 + reinterpret_cast < unsigned char > (v79) * 4) + 0x334) = 0;
                    //                    ecx78 = v79;
                    //                    *reinterpret_cast<int16_t*>(uint(edi15 + reinterpret_cast < unsigned char > (ecx78) * 2) + 0x3fc) = -2;
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

        public void _get_damage_descriptor()
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

            for(int i = 0; i < item.AbilityId.Length; i++)
            {
                if(item.AbilityId[i] == abilityId)
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

        public void _get_legal_level()
        {

            //TODO: Insert Logic.
        }

        public int _get_light_level(PlayerType player)
        {
            int lightLevel = 0;

            int mapId = player.MapNumber;
            int roomId = player.RoomNumber;

            RoomType room = _get_room_data(mapId, roomId);

            if(room.MapNumber > 0)
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

        public void _get_message_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_monster_ability_value()
        {

            //TODO: Insert Logic.
        }

        public void _get_monster_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_mud_ini_value()
        {

            //TODO: Insert Logic.
        }

        public void _get_my_attack_type()
        {

            //TODO: Insert Logic.
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

        public void _get_shop_data()
        {

            //TODO: Insert Logic.
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

            for(int i = 0; i < spell.AbilityId.Length; i++)
            {
                if(spell.AbilityId[i] == abilityId)
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
            if(abilityId == AbilityTypes.Speed)
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

        public void _get_user_number_from_id()
        {

            //TODO: Insert Logic.
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

        public void _handle_commands()
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

            int playerIndexOffSet = 0;

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

            for(int i = 0; i < item.AbilityId.Length; i++)
            {
                if(item.AbilityId[i] == abilityId)
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
            if(_nextBuffer >= 10)
            {
                _nextBuffer = 0;
            }

            switch(_nextBuffer)
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
                int ebx12 = 0;

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

        public void _tell_room()
        {

            //TODO: Insert Logic.
        }

        public void _tell_user(string message, PlayerType fromPlayer, PlayerType toPlayer)
        {
            // send message from player to player.
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

        public void _update_dynamic_stats()
        {

            //TODO: Insert Logic.
        }

        public void _update_dynamic_with_ability()
        {

            //TODO: Insert Logic.
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
            for(int i = 0; i < player.SpellCasted.Length; i++)
            {
                if (player.SpellCasted[i] > 0)
                {
                    SpellType spellType = _get_spell_data(player.SpellCasted[i]).Value;

                    for (int s = 0; s < spellType.AbilityId.Length; s++)
                    { 
                        if(spellType.AbilityId[s] == abilityId)
                        {
                            return true;
                        }
                    }
                }
            }


            // 2. Check Race Data, if there is no race ability, then
            RaceType raceType = _get_race_data(player.Race);

            for(int i = 0; i < raceType.AbilityId.Length; i++)
            {
                if(raceType.AbilityId[i] == abilityId)
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
            for(int i = 0; i < player.AbilityId.Length; i++)
            {
                if(player.AbilityId[i] == abilityId)
                {
                    return true;
                }
            }

            // 4. Check Player Worn Items
            for(int i = 0; i < player.WornItem.Length; i++)
            {
                if(player.WornItem[i] > 0)
                {
                    ItemType itemType = _get_item_data(player.WornItem[i]);

                    for(int s = 0; s < itemType.AbilityId.Length; s++)
                    {
                        if(itemType.AbilityId[s] == abilityId)
                        {
                            return true;
                        }
                    }
                }
            }

            // 5. Check Player Main Hand. 
            if(player.WeaponHand > 0)
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
