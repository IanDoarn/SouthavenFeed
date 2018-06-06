﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tracker.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10.201.207.188")]
        public string ORACLE_HOST {
            get {
                return ((string)(this["ORACLE_HOST"]));
            }
            set {
                this["ORACLE_HOST"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("smsprd")]
        public string ORACLE_SID {
            get {
                return ((string)(this["ORACLE_SID"]));
            }
            set {
                this["ORACLE_SID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1521")]
        public string ORACLE_PORT {
            get {
                return ((string)(this["ORACLE_PORT"]));
            }
            set {
                this["ORACLE_PORT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("logistics")]
        public string ORACLE_USERNAME {
            get {
                return ((string)(this["ORACLE_USERNAME"]));
            }
            set {
                this["ORACLE_USERNAME"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("log78gist")]
        public string ORACLE_PASSWORD {
            get {
                return ((string)(this["ORACLE_PASSWORD"]));
            }
            set {
                this["ORACLE_PASSWORD"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("WITH TRANSFERS AS (\r\n    SELECT\r\n      T.ID                                 AS TR" +
            "ANSFER_ID,\r\n\r\n      CASE\r\n      WHEN PK.ID = B.ID\r\n        THEN NULL\r\n      ELSE" +
            " PK.ID\r\n      END                                  AS FROM_PACKAGE_ID,\r\n\r\n\r\n    " +
            "  PK.STATUS                            AS FROM_PACKAGE_STATUS,\r\n\r\n      CASE\r\n  " +
            "    WHEN PK2.ID = B2.ID\r\n        THEN NULL\r\n      ELSE PK2.ID\r\n      END        " +
            "                          AS TO_PACKAGE_ID,\r\n\r\n      PK2.STATUS                 " +
            "          AS TO_PACKAGE_STATUS,\r\n      B.ID                                 AS F" +
            "ROM_BIN_ID,\r\n      B2.ID                                AS TO_BIN_ID,\r\n      \'X-" +
            "\' || T.ID                         AS TRANSFER_NUMBER,\r\n\r\n      /* DATES ARE ADJU" +
            "STED BY 5 HOURS TO BE CORRECTED FOR CST/CDT */\r\n      T.CREATED_DATE - 5 / 24   " +
            "           AS CREATED_DATE,\r\n      T.COMPLETED_DATE - 5 / 24            AS COMPL" +
            "ETED_DATE,\r\n\r\n      EM.FIRST_NAME || \' \' || EM.LAST_NAME AS EMPLOYEE_USER,\r\n    " +
            "  T.TRANSFER_TYPE,\r\n\r\n      /* DEFINING EACH TYPE OF TRANSFER*/\r\n      CASE\r\n   " +
            "   WHEN T.TRANSFER_TYPE = 1\r\n        THEN \'ITEM_FROM_BIN_TO_KIT\'\r\n      WHEN T.T" +
            "RANSFER_TYPE = 2\r\n        THEN \'ITEM_FROM_BIN_TO_BIN\'\r\n      WHEN T.TRANSFER_TYP" +
            "E = 3\r\n        THEN \'ITEM_FROM_BIN_TO_PACKAGE\'\r\n      WHEN T.TRANSFER_TYPE = 6\r\n" +
            "        THEN \'ITEM_FROM_PACKAGE_TO_BIN\'\r\n      WHEN T.TRANSFER_TYPE = 7\r\n       " +
            " THEN \'ITEM_FROM_PACKAGE_TO_PACKAGE\'\r\n      WHEN T.TRANSFER_TYPE = 10\r\n        T" +
            "HEN \'ITEM_FROM_LOAN_TO_BIN\'\r\n      WHEN T.TRANSFER_TYPE = 13\r\n        THEN \'COMP" +
            "ONENT_TO_KIT\'\r\n      WHEN T.TRANSFER_TYPE = 14\r\n        THEN \'COMPONENT_TO_BIN\'\r" +
            "\n      WHEN T.TRANSFER_TYPE = 17\r\n        THEN \'KIT_FROM_BIN_TO_BIN\'\r\n      WHEN" +
            " T.TRANSFER_TYPE = 18\r\n        THEN \'KIT_FROM_BIN_TO_PACKAGE\'\r\n      WHEN T.TRAN" +
            "SFER_TYPE = 20\r\n        THEN \'KIT_FROM_PACKAGE_TO_BIN\'\r\n      WHEN T.TRANSFER_TY" +
            "PE = 21\r\n        THEN \'KIT_FROM_PACKAGE_TO_PACKAGE\'\r\n      WHEN T.TRANSFER_TYPE " +
            "= 23\r\n        THEN \'KIT_FROM_LOAN_TO_BIN\'\r\n      ELSE \'OTHER\'\r\n      END        " +
            "                          AS TRANSFER_DESCRIPTION,\r\n\r\n      /* BECAUSE INVENTORY" +
            " CAN BE TRANSFERRED TO OTHER CONTAINERS BESIDES WHAT IS LISTED\r\n    IN THE BIN T" +
            "ABLE, IF THE TO BIN OR FROM BIN IS NOT IN THE BIN TABLE, WE SIMPLY\r\n    SHOW THE" +
            " VALUE AS NULL*/\r\n\r\n      CASE\r\n      WHEN B.ZONE IS NULL AND T.FROM_CONTAINER_T" +
            "YPE != 1\r\n        THEN CASE\r\n             WHEN T.FROM_CONTAINER_TYPE = 3\r\n      " +
            "         THEN \'PKG-\' || PK.ID\r\n             WHEN T.FROM_CONTAINER_TYPE = 2\r\n    " +
            "           THEN P2.PRODUCT_NUMBER || \'{\' || PS.SERIAL_NUMBER || \'}\'\r\n           " +
            "  END\r\n      ELSE B.ZONE || \'-\' || B.POSITION || \'-\' || B.SHELF\r\n      END      " +
            "                            AS FROM_BIN,\r\n\r\n      B.ZONE                        " +
            "       AS FROM_BIN_ZONE,\r\n\r\n      CASE\r\n      WHEN B2.ZONE IS NULL AND T.TO_CONT" +
            "AINER_TYPE != 1\r\n        THEN CASE\r\n             WHEN T.TO_CONTAINER_TYPE = 3\r\n " +
            "              THEN \'PKG-\' || PK2.ID\r\n             WHEN T.TO_CONTAINER_TYPE = 2\r\n" +
            "               THEN P2.PRODUCT_NUMBER || \'{\' || PS.SERIAL_NUMBER || \'}\'\r\n       " +
            "      END\r\n      ELSE B2.ZONE || \'-\' || B2.POSITION || \'-\' || B2.SHELF\r\n      EN" +
            "D                                  AS TO_BIN,\r\n\r\n      B2.ZONE                  " +
            "            AS TO_BIN_ZONE,\r\n\r\n      P.PRODUCT_TYPE,\r\n\r\n      /* DEFINING FROM A" +
            "ND TO CONTAINER TYPES */\r\n      CASE\r\n      WHEN T.FROM_CONTAINER_TYPE = 1\r\n    " +
            "    THEN \'BIN\'\r\n      WHEN T.FROM_CONTAINER_TYPE = 2\r\n        THEN \'KIT\'\r\n      " +
            "WHEN T.FROM_CONTAINER_TYPE = 3\r\n        THEN \'PACKAGE\'\r\n      WHEN T.FROM_CONTAI" +
            "NER_TYPE = 4\r\n        THEN \'LOAN\'\r\n      END                                  AS" +
            " FROM_CONTAINER,\r\n\r\n      CASE\r\n      WHEN T.TO_CONTAINER_TYPE = 1\r\n        THEN" +
            " \'BIN\'\r\n      WHEN T.TO_CONTAINER_TYPE = 2\r\n        THEN \'KIT\'\r\n      WHEN T.TO_" +
            "CONTAINER_TYPE = 3\r\n        THEN \'PACKAGE\'\r\n      WHEN T.TO_CONTAINER_TYPE = 4\r\n" +
            "        THEN \'LOAN\'\r\n      END                                  AS TO_CONTAINER\r" +
            "\n    FROM\r\n      SMS_WRITE.TRANSFER T\r\n      LEFT JOIN SMS_WRITE.PRODUCT P ON T." +
            "PRODUCT_ID = P.ID\r\n      LEFT JOIN SMS_WRITE.PACKAGE PK ON T.FROM_CONTAINER_ID =" +
            " PK.ID\r\n      LEFT JOIN SMS_WRITE.PACKAGE PK2 ON T.TO_CONTAINER_ID = PK2.ID\r\n   " +
            "   LEFT JOIN SMS_WRITE.STOCK S ON S.ID = T.FROM_STOCK_ID\r\n      LEFT JOIN SMS_WR" +
            "ITE.PRODUCT P2 ON T.TO_KIT_PRODUCT_ID = P2.ID\r\n      LEFT JOIN SMS_WRITE.PRODUCT" +
            "_SERIAL PS ON T.TO_KIT_SERIAL_ID = PS.ID\r\n      LEFT JOIN SMS_WRITE.USER_TABLE U" +
            " ON U.ID = T.ASSIGNED_USER_ID\r\n      LEFT JOIN SMS_WRITE.EMPLOYEE EM ON EM.USER_" +
            "ID = U.ID\r\n      LEFT JOIN SMS_WRITE.BIN B ON T.FROM_CONTAINER_ID = B.ID\r\n      " +
            "LEFT JOIN SMS_WRITE.BIN B2 ON T.TO_CONTAINER_ID = B2.ID\r\n    WHERE\r\n      T.LOCA" +
            "TION_TYPE = 1\r\n      AND T.LOCATION_ID = 370\r\n      AND T.STATUS = 2\r\n      AND " +
            "TO_CHAR(T.COMPLETED_DATE - 5 / 24, \'MM-DD-YYYY\') = TO_CHAR(CURRENT_DATE - 5 / 24" +
            ", \'MM-DD-YYYY\')\r\n      AND T.CREATED_DATE > CURRENT_DATE - 14\r\n      AND EM.FIRS" +
            "T_NAME || \' \' || EM.LAST_NAME IN (\r\n        \'LAKESHIA LIGGINS\',\r\n        \'ROLAND" +
            "O FLORES\',\r\n        \'FELECIA TUGGLE\',\r\n        \'SAM THOMAS\',\r\n        \'CYNTHIA S" +
            "COTT\',\r\n        \'RAYSHALINA PETTIGREW\',\r\n        \'THIOUBALO SY\',\r\n        \'TIFFA" +
            "NY THOMAS\',\r\n        \'SHANIKA MCCRAVEN\',\r\n        \'JAMES SULLIVAN\',\r\n        \'NO" +
            "RMA CISNEROS\',\r\n        \'JACQUELINE LOPEZ\',\r\n        \'KASEY WILSON\',\r\n        \'J" +
            "EFFERY ROBINSON\'\r\n      )\r\n    GROUP BY\r\n      EM.SITE_ID,\r\n      P.PRODUCT_TYPE" +
            ",\r\n      P2.PRODUCT_NUMBER,\r\n      PS.SERIAL_NUMBER,\r\n      T.TRANSFER_TYPE,\r\n  " +
            "    U.ID,\r\n      T.ID,\r\n      PK.ID, PK2.ID,\r\n      B.ID, B2.ID,\r\n      T.CREATE" +
            "D_DATE,\r\n      T.COMPLETED_DATE,\r\n      PK.STATUS, PK2.STATUS,\r\n      EM.FIRST_N" +
            "AME, EM.LAST_NAME,\r\n      B.ZONE, B.SHELF, B.POSITION,\r\n      B2.ZONE, B2.SHELF," +
            " B2.POSITION,\r\n      T.FROM_CONTAINER_TYPE, T.TO_CONTAINER_TYPE\r\n    ORDER BY\r\n " +
            "     T.COMPLETED_DATE\r\n),\r\n    TRANSFER_DEFINITIONS AS (\r\n      SELECT\r\n        " +
            "TRANSFER_NUMBER,\r\n        TRANSFER_TYPE,\r\n        EMPLOYEE_USER AS EMPLOYEE,\r\n  " +
            "      /* DEFINE TYPE OF TRANSFER */\r\n        CASE\r\n        -- PIECE INBOUND TRAN" +
            "SFERS\r\n        WHEN TRANSFER_TYPE = ANY (6, 7, 10, 20, 21, 23) AND PRODUCT_TYPE " +
            "= 0\r\n          THEN \'PIECE_INBOUND_TRANSFER\'\r\n        -- KIT INBOUND TRANSFERS\r\n" +
            "        WHEN TRANSFER_TYPE = ANY (6, 7, 10, 20, 21, 23) AND PRODUCT_TYPE = 1\r\n  " +
            "        THEN \'KIT_INBOUND_TRANSFER\'\r\n        -- INSTRUMENT INBOUND TRANSFERS\r\n  " +
            "      WHEN TRANSFER_TYPE = ANY (6, 7, 10, 20, 21, 23) AND PRODUCT_TYPE = 3\r\n    " +
            "      THEN \'INSTRUMENT_INBOUND_TRANSFER\'\r\n        /* PUT AWAY TRANSFERS, SET TO " +
            "ONLY CAPTURE TRANSFERS FROM NEW KIT ASSEMBLY OR VEHICLES */\r\n        WHEN TRANSF" +
            "ER_TYPE = ANY (2, 17, 14) AND TO_BIN_ZONE IS NOT NULL AND\r\n             REGEXP_L" +
            "IKE(FROM_BIN_ZONE, \'^(Vehicle\\s\\d|New Kit Assembly)\')\r\n          THEN \'PUTAWAY_T" +
            "RANSFER\'\r\n        /* PUT AWAY TRANSFERS FROM PACKAGES TO BIN, FOR THE RARE CASE " +
            "A PACKAGE IS NOT SHIPPED */\r\n        WHEN TRANSFER_TYPE = ANY (6, 20) AND REGEXP" +
            "_LIKE(TO_BIN_ZONE, \'(G\\d|R\\d|I\\d)\')\r\n          THEN \'PUTAWAY_TRANSFER\'\r\n        " +
            "-- KIT BUILDS\r\n        WHEN TRANSFER_TYPE = ANY (1, 13)\r\n          THEN \'KIT_BUI" +
            "LD_TRANSFER\'\r\n        -- OUTBOUND TRANSFER\r\n        WHEN TRANSFER_TYPE = ANY (3," +
            " 7, 18, 21)\r\n          THEN \'OUTBOUND_TRANSFER\'\r\n        ELSE \'OTHER_TRANSFERS\'\r" +
            "\n        END           AS TYPE_OF_TRANSFER\r\n      FROM\r\n        TRANSFERS\r\n  ),\r" +
            "\n    TRANSFERS_BY_DEFINED_TYPE AS (\r\n      SELECT DISTINCT\r\n        TD.EMPLOYEE," +
            "\r\n        TD.TYPE_OF_TRANSFER,\r\n        COUNT(TD.TYPE_OF_TRANSFER) AS NUMBER_BY_" +
            "TYPE\r\n      FROM\r\n        TRANSFER_DEFINITIONS TD\r\n      GROUP BY\r\n        TD.EM" +
            "PLOYEE,\r\n        TD.TYPE_OF_TRANSFER\r\n  ),\r\n    TRANSPOSED_DATA AS (\r\n      SELE" +
            "CT\r\n        EMPLOYEE,\r\n        MAX(CASE WHEN TYPE_OF_TRANSFER = \'KIT_INBOUND_TRA" +
            "NSFER\'\r\n          THEN NUMBER_BY_TYPE\r\n            ELSE 0 END) AS KIT_INBOUND_TR" +
            "ANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_OF_TRANSFER = \'PIECE_INBOUND_TRANSFER\'\r\n  " +
            "        THEN NUMBER_BY_TYPE\r\n            ELSE 0 END) AS PIECE_INBOUND_TRANSFER,\r" +
            "\n\r\n        MAX(CASE WHEN TYPE_OF_TRANSFER = \'INSTRUMENT_INBOUND_TRANSFER\'\r\n     " +
            "     THEN NUMBER_BY_TYPE\r\n            ELSE 0 END) AS INSTRUMENT_INBOUND_TRANSFER" +
            ",\r\n\r\n        MAX(CASE WHEN TYPE_OF_TRANSFER = \'PUTAWAY_TRANSFER\'\r\n          THEN" +
            " NUMBER_BY_TYPE\r\n            ELSE 0 END) AS PUTAWAY_TRANSFER,\r\n\r\n        MAX(CAS" +
            "E WHEN TYPE_OF_TRANSFER = \'KIT_BUILD_TRANSFER\'\r\n          THEN NUMBER_BY_TYPE\r\n " +
            "           ELSE 0 END) AS KIT_BUILD_TRANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_OF_T" +
            "RANSFER = \'OUTBOUND_TRANSFER\'\r\n          THEN NUMBER_BY_TYPE\r\n            ELSE 0" +
            " END) AS OUTBOUND_TRANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_OF_TRANSFER = \'OTHER_T" +
            "RANSFERS\'\r\n          THEN NUMBER_BY_TYPE\r\n            ELSE 0 END) AS OTHER_TRANS" +
            "FER\r\n      FROM\r\n        TRANSFERS_BY_DEFINED_TYPE\r\n      GROUP BY\r\n        EMPL" +
            "OYEE\r\n  ),\r\n    EMPLOYEE_PRODUCTIVITY AS (\r\n      SELECT\r\n        EMPLOYEE,\r\n\r\n " +
            "       KIT_INBOUND_TRANSFER,\r\n        ROUND((KIT_INBOUND_TRANSFER / 6.85) / (60 " +
            "/ 4), 2)         AS KIT_INBOUND_PROD,\r\n\r\n        PIECE_INBOUND_TRANSFER,\r\n      " +
            "  ROUND((PIECE_INBOUND_TRANSFER / 6.85) / (60 / 0.25), 2)    AS PIECE_INBOUND_PR" +
            "OD,\r\n\r\n        INSTRUMENT_INBOUND_TRANSFER,\r\n        ROUND((INSTRUMENT_INBOUND_T" +
            "RANSFER / 6.85) / (60 / 15), 2) AS INSTRUMENT_INBOUND_PROD,\r\n\r\n        PUTAWAY_T" +
            "RANSFER,\r\n        ROUND((PUTAWAY_TRANSFER / 6.85) / (60 / 1), 2)             AS " +
            "PUTAWAY_PROD,\r\n\r\n        KIT_BUILD_TRANSFER,\r\n        ROUND((KIT_BUILD_TRANSFER " +
            "/ 6.85) / (60 / 3), 2)           AS KIT_BUILD_PROD,\r\n\r\n        OUTBOUND_TRANSFER" +
            ",\r\n        ROUND((OUTBOUND_TRANSFER / 6.85) / (60 / 2.5), 2)          AS OUTBOUN" +
            "D_PROD,\r\n\r\n        OTHER_TRANSFER,\r\n        ROUND(((OTHER_TRANSFER * 100) / (\r\n " +
            "         KIT_BUILD_TRANSFER + KIT_INBOUND_TRANSFER + PIECE_INBOUND_TRANSFER + IN" +
            "STRUMENT_INBOUND_TRANSFER +\r\n          OUTBOUND_TRANSFER\r\n          + PUTAWAY_TR" +
            "ANSFER + OTHER_TRANSFER)) / 100, 2)                 AS OTHER_PROD\r\n\r\n      FROM\r" +
            "\n        TRANSPOSED_DATA\r\n  )\r\nSELECT\r\n  EMPLOYEE,\r\n  KIT_INBOUND_TRANSFER,\r\n  P" +
            "IECE_INBOUND_TRANSFER,\r\n  INSTRUMENT_INBOUND_TRANSFER,\r\n  PUTAWAY_TRANSFER,\r\n  K" +
            "IT_BUILD_TRANSFER,\r\n  OUTBOUND_TRANSFER,\r\n  OTHER_TRANSFER,\r\n  (KIT_INBOUND_PROD" +
            " + PIECE_INBOUND_PROD + INSTRUMENT_INBOUND_PROD + PUTAWAY_PROD + KIT_BUILD_PROD " +
            "+ OUTBOUND_PROD ) AS TOTAL_PRODUCTIVITY\r\nFROM\r\n  EMPLOYEE_PRODUCTIVITY")]
        public string ORACLE_COMPLETED_WORK {
            get {
                return ((string)(this["ORACLE_COMPLETED_WORK"]));
            }
            set {
                this["ORACLE_COMPLETED_WORK"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("WITH TRANSFERS AS (\r\n    SELECT\r\n      T.ID                                 AS TR" +
            "ANSFER_ID,\r\n\r\n      CASE\r\n      WHEN PK.ID = B.ID\r\n        THEN NULL\r\n      ELSE" +
            " PK.ID\r\n      END                                  AS FROM_PACKAGE_ID,\r\n\r\n\r\n    " +
            "  PK.STATUS                            AS FROM_PACKAGE_STATUS,\r\n\r\n      CASE\r\n  " +
            "    WHEN PK2.ID = B2.ID\r\n        THEN NULL\r\n      ELSE PK2.ID\r\n      END        " +
            "                          AS TO_PACKAGE_ID,\r\n\r\n      PK2.STATUS                 " +
            "          AS TO_PACKAGE_STATUS,\r\n      B.ID                                 AS F" +
            "ROM_BIN_ID,\r\n      B2.ID                                AS TO_BIN_ID,\r\n      \'X-" +
            "\' || T.ID                         AS TRANSFER_NUMBER,\r\n\r\n      /* DATES ARE ADJU" +
            "STED BY 5 HOURS TO BE CORRECTED FOR CST/CDT */\r\n      T.CREATED_DATE - 5 / 24   " +
            "           AS CREATED_DATE,\r\n      T.COMPLETED_DATE - 5 / 24            AS COMPL" +
            "ETED_DATE,\r\n\r\n      EM.FIRST_NAME || \' \' || EM.LAST_NAME AS EMPLOYEE_USER,\r\n    " +
            "  T.TRANSFER_TYPE,\r\n\r\n      /* DEFINING EACH TYPE OF TRANSFER*/\r\n      CASE\r\n   " +
            "   WHEN T.TRANSFER_TYPE = 1\r\n        THEN \'ITEM_FROM_BIN_TO_KIT\'\r\n      WHEN T.T" +
            "RANSFER_TYPE = 2\r\n        THEN \'ITEM_FROM_BIN_TO_BIN\'\r\n      WHEN T.TRANSFER_TYP" +
            "E = 3\r\n        THEN \'ITEM_FROM_BIN_TO_PACKAGE\'\r\n      WHEN T.TRANSFER_TYPE = 6\r\n" +
            "        THEN \'ITEM_FROM_PACKAGE_TO_BIN\'\r\n      WHEN T.TRANSFER_TYPE = 7\r\n       " +
            " THEN \'ITEM_FROM_PACKAGE_TO_PACKAGE\'\r\n      WHEN T.TRANSFER_TYPE = 10\r\n        T" +
            "HEN \'ITEM_FROM_LOAN_TO_BIN\'\r\n      WHEN T.TRANSFER_TYPE = 13\r\n        THEN \'COMP" +
            "ONENT_TO_KIT\'\r\n      WHEN T.TRANSFER_TYPE = 14\r\n        THEN \'COMPONENT_TO_BIN\'\r" +
            "\n      WHEN T.TRANSFER_TYPE = 17\r\n        THEN \'KIT_FROM_BIN_TO_BIN\'\r\n      WHEN" +
            " T.TRANSFER_TYPE = 18\r\n        THEN \'KIT_FROM_BIN_TO_PACKAGE\'\r\n      WHEN T.TRAN" +
            "SFER_TYPE = 20\r\n        THEN \'KIT_FROM_PACKAGE_TO_BIN\'\r\n      WHEN T.TRANSFER_TY" +
            "PE = 21\r\n        THEN \'KIT_FROM_PACKAGE_TO_PACKAGE\'\r\n      WHEN T.TRANSFER_TYPE " +
            "= 23\r\n        THEN \'KIT_FROM_LOAN_TO_BIN\'\r\n      ELSE \'OTHER\'\r\n      END        " +
            "                          AS TRANSFER_DESCRIPTION,\r\n\r\n      /* BECAUSE INVENTORY" +
            " CAN BE TRANSFERRED TO OTHER CONTAINERS BESIDES WHAT IS LISTED\r\n    IN THE BIN T" +
            "ABLE, IF THE TO BIN OR FROM BIN IS NOT IN THE BIN TABLE, WE SIMPLY\r\n    SHOW THE" +
            " VALUE AS NULL*/\r\n\r\n      CASE\r\n      WHEN B.ZONE IS NULL AND T.FROM_CONTAINER_T" +
            "YPE != 1\r\n        THEN CASE\r\n             WHEN T.FROM_CONTAINER_TYPE = 3\r\n      " +
            "         THEN \'PKG-\' || PK.ID\r\n             WHEN T.FROM_CONTAINER_TYPE = 2\r\n    " +
            "           THEN P2.PRODUCT_NUMBER || \'{\' || PS.SERIAL_NUMBER || \'}\'\r\n           " +
            "  END\r\n      ELSE B.ZONE || \'-\' || B.POSITION || \'-\' || B.SHELF\r\n      END      " +
            "                            AS FROM_BIN,\r\n\r\n      B.ZONE                        " +
            "       AS FROM_BIN_ZONE,\r\n\r\n      CASE\r\n      WHEN B2.ZONE IS NULL AND T.TO_CONT" +
            "AINER_TYPE != 1\r\n        THEN CASE\r\n             WHEN T.TO_CONTAINER_TYPE = 3\r\n " +
            "              THEN \'PKG-\' || PK2.ID\r\n             WHEN T.TO_CONTAINER_TYPE = 2\r\n" +
            "               THEN P2.PRODUCT_NUMBER || \'{\' || PS.SERIAL_NUMBER || \'}\'\r\n       " +
            "      END\r\n      ELSE B2.ZONE || \'-\' || B2.POSITION || \'-\' || B2.SHELF\r\n      EN" +
            "D                                  AS TO_BIN,\r\n\r\n      B2.ZONE                  " +
            "            AS TO_BIN_ZONE,\r\n\r\n      P.PRODUCT_TYPE,\r\n\r\n      /* DEFINING FROM A" +
            "ND TO CONTAINER TYPES */\r\n      CASE\r\n      WHEN T.FROM_CONTAINER_TYPE = 1\r\n    " +
            "    THEN \'BIN\'\r\n      WHEN T.FROM_CONTAINER_TYPE = 2\r\n        THEN \'KIT\'\r\n      " +
            "WHEN T.FROM_CONTAINER_TYPE = 3\r\n        THEN \'PACKAGE\'\r\n      WHEN T.FROM_CONTAI" +
            "NER_TYPE = 4\r\n        THEN \'LOAN\'\r\n      END                                  AS" +
            " FROM_CONTAINER,\r\n\r\n      CASE\r\n      WHEN T.TO_CONTAINER_TYPE = 1\r\n        THEN" +
            " \'BIN\'\r\n      WHEN T.TO_CONTAINER_TYPE = 2\r\n        THEN \'KIT\'\r\n      WHEN T.TO_" +
            "CONTAINER_TYPE = 3\r\n        THEN \'PACKAGE\'\r\n      WHEN T.TO_CONTAINER_TYPE = 4\r\n" +
            "        THEN \'LOAN\'\r\n      END                                  AS TO_CONTAINER\r" +
            "\n    FROM\r\n      SMS_WRITE.TRANSFER T\r\n      LEFT JOIN SMS_WRITE.PRODUCT P ON T." +
            "PRODUCT_ID = P.ID\r\n      LEFT JOIN SMS_WRITE.PACKAGE PK ON T.FROM_CONTAINER_ID =" +
            " PK.ID\r\n      LEFT JOIN SMS_WRITE.PACKAGE PK2 ON T.TO_CONTAINER_ID = PK2.ID\r\n   " +
            "   LEFT JOIN SMS_WRITE.STOCK S ON S.ID = T.FROM_STOCK_ID\r\n      LEFT JOIN SMS_WR" +
            "ITE.PRODUCT P2 ON T.TO_KIT_PRODUCT_ID = P2.ID\r\n      LEFT JOIN SMS_WRITE.PRODUCT" +
            "_SERIAL PS ON T.TO_KIT_SERIAL_ID = PS.ID\r\n      LEFT JOIN SMS_WRITE.USER_TABLE U" +
            " ON U.ID = T.ASSIGNED_USER_ID\r\n      LEFT JOIN SMS_WRITE.EMPLOYEE EM ON EM.USER_" +
            "ID = U.ID\r\n      LEFT JOIN SMS_WRITE.BIN B ON T.FROM_CONTAINER_ID = B.ID\r\n      " +
            "LEFT JOIN SMS_WRITE.BIN B2 ON T.TO_CONTAINER_ID = B2.ID\r\n    WHERE\r\n      T.LOCA" +
            "TION_TYPE = 1\r\n      AND T.LOCATION_ID = 370\r\n      AND T.STATUS = 2\r\n      AND " +
            "TO_CHAR(T.COMPLETED_DATE - 5 / 24, \'MM-DD-YYYY\') = TO_CHAR(CURRENT_DATE - 5 / 24" +
            ", \'MM-DD-YYYY\')\r\n      AND T.CREATED_DATE > CURRENT_DATE - 14\r\n      AND EM.FIRS" +
            "T_NAME || \' \' || EM.LAST_NAME IN (\r\n        \'ZWAN LANDFAIR\',\r\n        \'NATASHA A" +
            "SKEW\',\r\n        \'IAN DOARN\',\r\n        \'SHAY ROBINSON\',\r\n        \'NICHOLAS THOMAS" +
            "\',\r\n        \'DONAVAN STRICKLAND\',\r\n        \'GONZLA JOYNER\'\r\n      )\r\n    GROUP B" +
            "Y\r\n      EM.SITE_ID,\r\n      P.PRODUCT_TYPE,\r\n      P2.PRODUCT_NUMBER,\r\n      PS." +
            "SERIAL_NUMBER,\r\n      T.TRANSFER_TYPE,\r\n      U.ID,\r\n      T.ID,\r\n      PK.ID, P" +
            "K2.ID,\r\n      B.ID, B2.ID,\r\n      T.CREATED_DATE,\r\n      T.COMPLETED_DATE,\r\n    " +
            "  PK.STATUS, PK2.STATUS,\r\n      EM.FIRST_NAME, EM.LAST_NAME,\r\n      B.ZONE, B.SH" +
            "ELF, B.POSITION,\r\n      B2.ZONE, B2.SHELF, B2.POSITION,\r\n      T.FROM_CONTAINER_" +
            "TYPE, T.TO_CONTAINER_TYPE\r\n    ORDER BY\r\n      T.COMPLETED_DATE\r\n),\r\n    TRANSFE" +
            "R_DEFINITIONS AS (\r\n      SELECT\r\n        TRANSFER_NUMBER,\r\n        TRANSFER_TYP" +
            "E,\r\n        EMPLOYEE_USER AS EMPLOYEE,\r\n        /* DEFINE TYPE OF TRANSFER */\r\n " +
            "       CASE\r\n        -- PIECE INBOUND TRANSFERS\r\n        WHEN TRANSFER_TYPE = AN" +
            "Y (6, 7, 10, 20, 21, 23) AND PRODUCT_TYPE = 0\r\n          THEN \'PIECE_INBOUND_TRA" +
            "NSFER\'\r\n        -- KIT INBOUND TRANSFERS\r\n        WHEN TRANSFER_TYPE = ANY (6, 7" +
            ", 10, 20, 21, 23) AND PRODUCT_TYPE = 1\r\n          THEN \'KIT_INBOUND_TRANSFER\'\r\n " +
            "       -- INSTRUMENT INBOUND TRANSFERS\r\n        WHEN TRANSFER_TYPE = ANY (6, 7, " +
            "10, 20, 21, 23) AND PRODUCT_TYPE = 3\r\n          THEN \'INSTRUMENT_INBOUND_TRANSFE" +
            "R\'\r\n        /* PUT AWAY TRANSFERS, SET TO ONLY CAPTURE TRANSFERS FROM NEW KIT AS" +
            "SEMBLY OR VEHICLES */\r\n        WHEN TRANSFER_TYPE = ANY (2, 17, 14) AND TO_BIN_Z" +
            "ONE IS NOT NULL AND\r\n             REGEXP_LIKE(FROM_BIN_ZONE, \'^(Vehicle\\s\\d|New " +
            "Kit Assembly)\')\r\n          THEN \'PUTAWAY_TRANSFER\'\r\n        /* PUT AWAY TRANSFER" +
            "S FROM PACKAGES TO BIN, FOR THE RARE CASE A PACKAGE IS NOT SHIPPED */\r\n        W" +
            "HEN TRANSFER_TYPE = ANY (6, 20) AND REGEXP_LIKE(TO_BIN_ZONE, \'(G\\d|R\\d|I\\d)\')\r\n " +
            "         THEN \'PUTAWAY_TRANSFER\'\r\n        -- KIT BUILDS\r\n        WHEN TRANSFER_T" +
            "YPE = ANY (1, 13)\r\n          THEN \'KIT_BUILD_TRANSFER\'\r\n        -- OUTBOUND TRAN" +
            "SFER\r\n        WHEN TRANSFER_TYPE = ANY (3, 7, 18, 21)\r\n          THEN \'OUTBOUND_" +
            "TRANSFER\'\r\n        ELSE \'OTHER_TRANSFERS\'\r\n        END           AS TYPE_OF_TRAN" +
            "SFER\r\n      FROM\r\n        TRANSFERS\r\n  ),\r\n    TRANSFERS_BY_DEFINED_TYPE AS (\r\n " +
            "     SELECT DISTINCT\r\n        TD.EMPLOYEE,\r\n        TD.TYPE_OF_TRANSFER,\r\n      " +
            "  COUNT(TD.TYPE_OF_TRANSFER) AS NUMBER_BY_TYPE\r\n      FROM\r\n        TRANSFER_DEF" +
            "INITIONS TD\r\n      GROUP BY\r\n        TD.EMPLOYEE,\r\n        TD.TYPE_OF_TRANSFER\r\n" +
            "  ),\r\n    TRANSPOSED_DATA AS (\r\n      SELECT\r\n        EMPLOYEE,\r\n        MAX(CAS" +
            "E WHEN TYPE_OF_TRANSFER = \'KIT_INBOUND_TRANSFER\'\r\n          THEN NUMBER_BY_TYPE\r" +
            "\n            ELSE 0 END) AS KIT_INBOUND_TRANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_" +
            "OF_TRANSFER = \'PIECE_INBOUND_TRANSFER\'\r\n          THEN NUMBER_BY_TYPE\r\n         " +
            "   ELSE 0 END) AS PIECE_INBOUND_TRANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_OF_TRANS" +
            "FER = \'INSTRUMENT_INBOUND_TRANSFER\'\r\n          THEN NUMBER_BY_TYPE\r\n            " +
            "ELSE 0 END) AS INSTRUMENT_INBOUND_TRANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_OF_TRA" +
            "NSFER = \'PUTAWAY_TRANSFER\'\r\n          THEN NUMBER_BY_TYPE\r\n            ELSE 0 EN" +
            "D) AS PUTAWAY_TRANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_OF_TRANSFER = \'KIT_BUILD_T" +
            "RANSFER\'\r\n          THEN NUMBER_BY_TYPE\r\n            ELSE 0 END) AS KIT_BUILD_TR" +
            "ANSFER,\r\n\r\n        MAX(CASE WHEN TYPE_OF_TRANSFER = \'OUTBOUND_TRANSFER\'\r\n       " +
            "   THEN NUMBER_BY_TYPE\r\n            ELSE 0 END) AS OUTBOUND_TRANSFER,\r\n\r\n       " +
            " MAX(CASE WHEN TYPE_OF_TRANSFER = \'OTHER_TRANSFERS\'\r\n          THEN NUMBER_BY_TY" +
            "PE\r\n            ELSE 0 END) AS OTHER_TRANSFER\r\n      FROM\r\n        TRANSFERS_BY_" +
            "DEFINED_TYPE\r\n      GROUP BY\r\n        EMPLOYEE\r\n  ),\r\n    EMPLOYEE_PRODUCTIVITY " +
            "AS (\r\n      SELECT\r\n        EMPLOYEE,\r\n\r\n        KIT_INBOUND_TRANSFER,\r\n        " +
            "ROUND((KIT_INBOUND_TRANSFER / 6.85) / (60 / 4), 2)         AS KIT_INBOUND_PROD,\r" +
            "\n\r\n        PIECE_INBOUND_TRANSFER,\r\n        ROUND((PIECE_INBOUND_TRANSFER / 6.85" +
            ") / (60 / 0.25), 2)    AS PIECE_INBOUND_PROD,\r\n\r\n        INSTRUMENT_INBOUND_TRAN" +
            "SFER,\r\n        ROUND((INSTRUMENT_INBOUND_TRANSFER / 6.85) / (60 / 15), 2) AS INS" +
            "TRUMENT_INBOUND_PROD,\r\n\r\n        PUTAWAY_TRANSFER,\r\n        ROUND((PUTAWAY_TRANS" +
            "FER / 6.85) / (60 / 1), 2)             AS PUTAWAY_PROD,\r\n\r\n        KIT_BUILD_TRA" +
            "NSFER,\r\n        ROUND((KIT_BUILD_TRANSFER / 6.85) / (60 / 3), 2)           AS KI" +
            "T_BUILD_PROD,\r\n\r\n        OUTBOUND_TRANSFER,\r\n        ROUND((OUTBOUND_TRANSFER / " +
            "6.85) / (60 / 2.5), 2)          AS OUTBOUND_PROD,\r\n\r\n        OTHER_TRANSFER,\r\n  " +
            "      ROUND(((OTHER_TRANSFER * 100) / (\r\n          KIT_BUILD_TRANSFER + KIT_INBO" +
            "UND_TRANSFER + PIECE_INBOUND_TRANSFER + INSTRUMENT_INBOUND_TRANSFER +\r\n         " +
            " OUTBOUND_TRANSFER\r\n          + PUTAWAY_TRANSFER + OTHER_TRANSFER)) / 100, 2)   " +
            "       AS OTHER_PROD\r\n      FROM\r\n        TRANSPOSED_DATA\r\n  )\r\nSELECT\r\n  EMPLOY" +
            "EE,\r\n  KIT_INBOUND_TRANSFER,\r\n  PIECE_INBOUND_TRANSFER,\r\n  INSTRUMENT_INBOUND_TR" +
            "ANSFER,\r\n  PUTAWAY_TRANSFER,\r\n  KIT_BUILD_TRANSFER,\r\n  OUTBOUND_TRANSFER,\r\n  OTH" +
            "ER_TRANSFER,\r\n  (KIT_INBOUND_PROD + PIECE_INBOUND_PROD + INSTRUMENT_INBOUND_PROD" +
            " + PUTAWAY_PROD + KIT_BUILD_PROD + OUTBOUND_PROD +\r\n   OTHER_PROD) AS TOTAL_PROD" +
            "UCTIVITY\r\nFROM\r\n  EMPLOYEE_PRODUCTIVITY")]
        public string ORACLE_COMPLETED_WORK_OTHER {
            get {
                return ((string)(this["ORACLE_COMPLETED_WORK_OTHER"]));
            }
            set {
                this["ORACLE_COMPLETED_WORK_OTHER"] = value;
            }
        }
    }
}
