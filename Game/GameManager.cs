using ReMUD.Game.Btrieve;
using ReMUD.Game.Content;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.Utilities;
using System;

namespace ReMUD.Game
{
    /// <summary>
    /// The GameManager class will manage all the logic in the game currently.
    /// </summary>
    public class GameManager
    {
        public MetaContentManager ContentManager = new MetaContentManager();

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
                for (int i = 0; i < spell.Value.AbilityA.Length; i++)
                {
                    if (spell.Value.AbilityA[i] == abilityId)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public sbyte _user_is_wearing(PlayerType ecx, object a2, int itemId)
        {
            int ebx4;
            PlayerType? edx8 = null;
            int eax9;

            ebx4 = itemId;
            // eax7 = _get_player(ecx, a2, ebx5, ebp6, __return_address());
            //  edx8 = eax7;

            if (edx8 != null)
            {
                return 0;
            }
            else
            {
                eax9 = 0;

                do
                {
                    if (ebx4 == edx8.Value.WornItem[eax9])
                    {
                        break;
                    }

                    ++eax9;

                } while (eax9 < 20);
            }

            return 1;
        }

        public void _add_cast_spell_to_monster()
        {

            //TODO: Insert Logic.
        }

        public void _add_cast_spell_to_user()
        {

            //TODO: Insert Logic.
        }

        public void _add_delay()
        {

            //TODO: Insert Logic.
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

            //TODO: Insert Logic.
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

        public void _calculate_secondary_stats()
        {

            //TODO: Insert Logic.
        }

        public void _can_see()
        {

            //TODO: Insert Logic.
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

        public void _cmd_look()
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

        public void _cmd_use()
        {

            //TODO: Insert Logic.
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

        public void _convert_currency()
        {

            //TODO: Insert Logic.
        }

        public void _count_valid_targets()
        {

            //TODO: Insert Logic.
        }

        public void _create_player()
        {

            //TODO: Insert Logic.
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

        public void _delay_done()
        {

            //TODO: Insert Logic.
        }

        public void _delete_evil_points()
        {

            //TODO: Insert Logic.
        }

        public void _delete_monster()
        {

            //TODO: Insert Logic.
        }

        public void _delete_offline_mmud_user()
        {

            //TODO: Insert Logic.
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

            //TODO: Insert Logic.
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

        public void _energy_update_character()
        {

            //TODO: Insert Logic.
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

        public void _find_item_in_inventory()
        {

            //TODO: Insert Logic.
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

        public void _get_class_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_class_name()
        {

            //TODO: Insert Logic.
        }

        public void _get_coin_weight()
        {

            //TODO: Insert Logic.
        }

        public void _get_component_string()
        {

            //TODO: Insert Logic.
        }

        public void _get_damage_descriptor()
        {

            //TODO: Insert Logic.
        }

        public void _get_encumbrance_percent()
        {

            //TODO: Insert Logic.
        }

        public void _get_gang_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_hp_colour()
        {

            //TODO: Insert Logic.
        }

        public void _get_item_ability_value()
        {

            //TODO: Insert Logic.
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

            //TODO: Insert Logic.
        }

        public void _get_legal_level()
        {

            //TODO: Insert Logic.
        }

        public void _get_light_level()
        {

            //TODO: Insert Logic.
        }

        public void _get_max_weight()
        {

            //TODO: Insert Logic.
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

        public void _get_race_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_race_name()
        {

            //TODO: Insert Logic.
        }

        public void _get_random_name()
        {

            //TODO: Insert Logic.
        }

        public void _get_room_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_saved_evil_points()
        {

            //TODO: Insert Logic.
        }

        public void _get_shop_data()
        {

            //TODO: Insert Logic.
        }

        public void _get_shop_item_from_name()
        {

            //TODO: Insert Logic.
        }

        public void _get_spell_ability_value()
        {

            //TODO: Insert Logic.
        }

        public void _get_spell_from_name()
        {

            //TODO: Insert Logic.
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

        public void _get_user_ability_value()
        {

            //TODO: Insert Logic.
        }

        public void _get_user_currency()
        {

            //TODO: Insert Logic.
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
            rootDirectory = string.Format("{0}\\DATs", rootDirectory);

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

        public void _is_inside_autocombat()
        {

            //TODO: Insert Logic.
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

        public void _item_has_ability()
        {

            //TODO: Insert Logic.
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

        public void _ljnsame()
        {

            //TODO: Insert Logic.
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

            //TODO: Insert Logic.
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

        public void _stop_dragging_user()
        {

            //TODO: Insert Logic.
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

        public void _tell_user()
        {

            //TODO: Insert Logic.
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

        public void _user_has_ability()
        {

            //TODO: Insert Logic.
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
