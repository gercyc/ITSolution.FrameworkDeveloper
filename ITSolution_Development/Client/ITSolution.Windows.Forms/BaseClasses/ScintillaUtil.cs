using System;
using System.Drawing;
using ScintillaNET;

namespace ITSolution.Framework.GuiUtil
{
    public static class ScintillaUtil
    {

        public static void ConfigureHighlightingCpp(this Scintilla scintilla)
        {
            /*scintilla.Styles[Style.Cpp.CommentLine].Font = "Consolas";
            scintilla.Styles[Style.Cpp.CommentLine].Size = 10;
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
                                                                                           //scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            scintilla.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            scintilla.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            scintilla.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

            scintilla.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            scintilla.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");*/

            scintilla.Lexer = Lexer.Cpp;

            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            // Configure the CPP (C#) lexer styles
            scintilla.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            scintilla.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintilla.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            scintilla.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            scintilla.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            scintilla.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintilla.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintilla.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            scintilla.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;
            scintilla.Lexer = Lexer.Cpp;

            // Set the keywords
            scintilla.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            scintilla.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void");
        }

        public static void ConfigureLexer(this Scintilla scintilla, Lexer lexer)
        {
            if (lexer == ScintillaNET.Lexer.Cpp)
                scintilla.ConfigureHighlightingCpp();
            else if (lexer == ScintillaNET.Lexer.Xml)
                scintilla.ConfigureHighlightingXML();
            else if (lexer == ScintillaNET.Lexer.Sql)
                scintilla.ConfigureHighlightingSql();
        }

        public static void ConfigureHighlightingXML(this Scintilla scintilla)
        {
            // Reset the styles
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            // Set the XML Lexer
            scintilla.Lexer = Lexer.Xml;

            // Show line numbers
            scintilla.Margins[0].Width = 20;

            // Enable folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");
            scintilla.SetProperty("fold.html", "1");

            // Use Margin 2 for fold markers
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            // Set the Styles
            scintilla.StyleResetDefault();
            // I like fixed font for XML
            scintilla.Styles[Style.Default].Font = "Consolas";//modificado
            scintilla.Styles[Style.Default].Size = 12;//modificado
            scintilla.StyleClearAll();
            scintilla.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
            scintilla.Styles[Style.Xml.Entity].ForeColor = Color.Red;
            scintilla.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            scintilla.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
            scintilla.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
            scintilla.Styles[Style.Xml.DoubleString].ForeColor = Color.DeepPink;
            scintilla.Styles[Style.Xml.SingleString].ForeColor = Color.DeepPink;

        }

        public static void ConfigureHighlightingSql(this Scintilla scintilla)
        {

            scintilla.Lexer = Lexer.Sql;

            // Configure the default style
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            //memoSQL.Styles[Style.Default].BackColor = IntToColor(0x212121);
            //memoSQL.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            scintilla.StyleClearAll();

            scintilla.Styles[Style.Sql.Identifier].ForeColor = IntToColor(0x000000);
            scintilla.Styles[Style.Sql.Comment].ForeColor = IntToColor(0xBD758B);
            scintilla.Styles[Style.Sql.CommentLine].ForeColor = IntToColor(0x40BF57);
            scintilla.Styles[Style.Sql.CommentDoc].ForeColor = IntToColor(0x2FAE35);
            scintilla.Styles[Style.Sql.Number].ForeColor = IntToColor(0xFB00FD);
            scintilla.Styles[Style.Sql.String].ForeColor = IntToColor(0xFFFF00);
            scintilla.Styles[Style.Sql.Character].ForeColor = IntToColor(0xE95454);
            scintilla.Styles[Style.Sql.Operator].ForeColor = IntToColor(0x000000);
            scintilla.Styles[Style.Sql.CommentLineDoc].ForeColor = IntToColor(0x29c12c);
            scintilla.Styles[Style.Sql.Word].ForeColor = IntToColor(0x0000FF);
            scintilla.Styles[Style.Sql.Word2].ForeColor = IntToColor(0xF98906);
            scintilla.Styles[Style.Sql.CommentDocKeyword].ForeColor = IntToColor(0xB3D991);
            scintilla.Styles[Style.Sql.CommentDocKeywordError].ForeColor = IntToColor(0xFF0000);

            const string keywords = "@@identity all alter and any as asc authorization avg backup begin between break browse bulk by cascade case check checkpoint close clustered coalesce collate column commit compute constraint contains containstable continue convert count create cross current current_date current_time current_timestamp current_user cursor database databasepassword dateadd datediff datename datepart dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else  encryption errlvl escape except exec execute exists exit expression fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if in index inner insert intersect into is join key kill left like lineno load max min national nocheck nonclustered not null nullif of off offsets on open opendatasource openquery openrowset openxml option or  order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revoke right rollback rowcount rowguidcol rule save schema select session_user set setuser shutdown some statistics sum system_user table textsize then to top tran transaction trigger truncate tsequal union unique update updatetext use user values varying view waitfor when where while with writetext abort abs absolute access action ada add admin after aggregate alias all allocate also alter always analyse analyze and any are array as asc asensitive assertion assignment asymmetric at atomic attribute attributes authorization avg backward before begin bernoulli between bigint binary bit bitvar bit_length blob boolean both breadth by c cache call called cardinality cascade cascaded case cast catalog catalog_name ceil ceiling chain char character characteristics characters character_length character_set_catalog character_set_name character_set_schema char_length check checked checkpoint class class_origin clob close cluster coalesce cobol collate collation collation_catalog collation_name collation_schema collect column column_name command_function command_function_code comment commit committed completion condition condition_number connect connection connection_name constraint constraints constraint_catalog constraint_name constraint_schema constructor contains continue conversion convert copy corr corresponding count covar_pop covar_samp create createdb createuser cross csv cube cume_dist current current_date current_default_transform_group current_path current_role current_time current_timestamp current_transform_group_for_type current_user cursor cursor_name cycle data database date datetime_interval_code datetime_interval_precision day deallocate dec decimal declare default defaults deferrable deferred defined definer degree delete delimiter delimiters dense_rank depth deref derived desc describe descriptor destroy destructor deterministic diagnostics dictionary disconnect dispatch distinct do domain double drop dynamic dynamic_function dynamic_function_code each element else encoding encrypted end end-exec equals escape every except exception exclude excluding exclusive exec execute existing exists exp explain external extract false fetch filter final first float floor following for force foreign fortran forward found free freeze from full function fusion g general generated get global go goto grant granted group grouping handler having hierarchy hold host hour identity ignore ilike immediate immutable implementation implicit in including increment index indicator infix inherits initialize initially inner inout input insensitive insert instance instantiable instead int integer intersect intersection interval into invoker is isnull isolation iterate join k key key_member key_type lancompiler language large last lateral leading left length less level like limit listen ln load local localtime localtimestamp location locator lock lower m map match matched max maxvalue member merge message_length message_octet_length message_text method min minute minvalue mod mode modifies modify module month more move multiset mumps name names national natural nchar nclob nesting new next no nocreatedb nocreateuser none normalize normalized not nothing notify notnull nowait null nullable nullif nulls number numeric object octets octet_length of off offset oids old on only open operation operator option options or order ordering ordinality others out outer output over overlaps overlay overriding owner pad parameter parameters parameter_mode parameter_name parameter_ordinal_position parameter_specific_catalog parameter_specific_name parameter_specific_schema partial partition pascal password path percentile_cont percentile_disc percent_rank placing pli position postfix power preceding precision prefix preorder prepare preserve primary prior privileges procedural procedure public quote range rank read reads real recheck recursive ref references referencing regr_avgx regr_avgy regr_count regr_intercept regr_r2 regr_slope regr_sxx regr_sxy regr_syy reindex relative release rename repeatable replace reset restart restrict result return returned_cardinality returned_length returned_octet_length returned_sqlstate returns revoke right role rollback rollup routine routine_catalog routine_name routine_schema row rows row_count row_number rule savepoint scale schema schema_name scope scope_catalog scope_name scope_schema scroll search second section security select self sensitive sequence serializable server_name session session_user set setof sets share show similar simple size smallint some source space specific specifictype specific_name sql sqlcode sqlerror sqlexception sqlstate sqlwarning sqrt stable start state statement static statistics stddev_pop stddev_samp stdin stdout storage strict structure style subclass_origin sublist submultiset substring sum symmetric sysid system system_user table tablesample tablespace table_name temp template temporary terminate than then ties time timestamp timezone_hour timezone_minute to toast top_level_count trailing transaction transactions_committed transactions_rolled_back transaction_active transform transforms translate translation treat trigger trigger_catalog trigger_name trigger_schema trim true truncate trusted type uescape unbounded uncommitted under unencrypted union unique unknown unlisten unnamed unnest until update upper usage user user_defined_type_catalog user_defined_type_code user_defined_type_name user_defined_type_schema using vacuum valid validator value values varchar variable varying var_pop var_samp verbose view volatile when whenever where width_bucket window with within without work write year zone";
            scintilla.SetKeywords(0, keywords);
            // scintilla.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            //scintilla.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");
            //scintilla.SetKeywords(0, "add alter as asc authorization backup begin break browse bulk by cascade case check checkpoint close clustered column commit compute constraint containstable continue create current current_date cursor database dbcc deallocate declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor for foreign freetext freetexttable from full function goto grant group having holdlock identity identity_insert identitycol if index insert intersect into key kill lineno load merge national nocheck nonclustered of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select semantickeyphrasetable semanticsimilaritydetailstable semanticsimilaritytable set setuser shutdown statistics table tablesample textsize then to top tran transaction trigger truncate union unique updatetext use user values varying view waitfor when where while with within group writetext "
            // + "coalesce collate contains convert current_time current_timestamp current_user nullif session_user system_user try_convert tsequal update "
            //+ "all and any between cross exists in inner is join left like not null or outer pivot right some unpivot");

        }

        private static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        #region Teste

        #endregion
    }
}
