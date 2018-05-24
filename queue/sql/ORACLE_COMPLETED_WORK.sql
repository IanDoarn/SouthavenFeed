WITH TRANSFERS AS (
    SELECT
      T.ID                                 AS TRANSFER_ID,

      CASE
      WHEN PK.ID = B.ID
        THEN NULL
      ELSE PK.ID
      END                                  AS FROM_PACKAGE_ID,


      PK.STATUS                            AS FROM_PACKAGE_STATUS,

      CASE
      WHEN PK2.ID = B2.ID
        THEN NULL
      ELSE PK2.ID
      END                                  AS TO_PACKAGE_ID,

      PK2.STATUS                           AS TO_PACKAGE_STATUS,
      B.ID                                 AS FROM_BIN_ID,
      B2.ID                                AS TO_BIN_ID,
      'X-' || T.ID                         AS TRANSFER_NUMBER,

      /* DATES ARE ADJUSTED BY 5 HOURS TO BE CORRECTED FOR CST/CDT */
      T.CREATED_DATE - 5 / 24              AS CREATED_DATE,
      T.COMPLETED_DATE - 5 / 24            AS COMPLETED_DATE,

      EM.FIRST_NAME || ' ' || EM.LAST_NAME AS EMPLOYEE_USER,
      T.TRANSFER_TYPE,

      /* DEFINING EACH TYPE OF TRANSFER*/
      CASE
      WHEN T.TRANSFER_TYPE = 1
        THEN 'ITEM_FROM_BIN_TO_KIT'
      WHEN T.TRANSFER_TYPE = 2
        THEN 'ITEM_FROM_BIN_TO_BIN'
      WHEN T.TRANSFER_TYPE = 3
        THEN 'ITEM_FROM_BIN_TO_PACKAGE'
      WHEN T.TRANSFER_TYPE = 6
        THEN 'ITEM_FROM_PACKAGE_TO_BIN'
      WHEN T.TRANSFER_TYPE = 7
        THEN 'ITEM_FROM_PACKAGE_TO_PACKAGE'
      WHEN T.TRANSFER_TYPE = 10
        THEN 'ITEM_FROM_LOAN_TO_BIN'
      WHEN T.TRANSFER_TYPE = 13
        THEN 'COMPONENT_TO_KIT'
      WHEN T.TRANSFER_TYPE = 14
        THEN 'COMPONENT_TO_BIN'
      WHEN T.TRANSFER_TYPE = 17
        THEN 'KIT_FROM_BIN_TO_BIN'
      WHEN T.TRANSFER_TYPE = 18
        THEN 'KIT_FROM_BIN_TO_PACKAGE'
      WHEN T.TRANSFER_TYPE = 20
        THEN 'KIT_FROM_PACKAGE_TO_BIN'
      WHEN T.TRANSFER_TYPE = 21
        THEN 'KIT_FROM_PACKAGE_TO_PACKAGE'
      WHEN T.TRANSFER_TYPE = 23
        THEN 'KIT_FROM_LOAN_TO_BIN'
      ELSE 'OTHER'
      END                                  AS TRANSFER_DESCRIPTION,

      /* BECAUSE INVENTORY CAN BE TRANSFERRED TO OTHER CONTAINERS BESIDES WHAT IS LISTED
    IN THE BIN TABLE, IF THE TO BIN OR FROM BIN IS NOT IN THE BIN TABLE, WE SIMPLY
    SHOW THE VALUE AS NULL*/

      CASE
      WHEN B.ZONE IS NULL AND T.FROM_CONTAINER_TYPE != 1
        THEN CASE
             WHEN T.FROM_CONTAINER_TYPE = 3
               THEN 'PKG-' || PK.ID
             WHEN T.FROM_CONTAINER_TYPE = 2
               THEN P2.PRODUCT_NUMBER || '{' || PS.SERIAL_NUMBER || '}'
             END
      ELSE B.ZONE || '-' || B.POSITION || '-' || B.SHELF
      END                                  AS FROM_BIN,

      B.ZONE                               AS FROM_BIN_ZONE,

      CASE
      WHEN B2.ZONE IS NULL AND T.TO_CONTAINER_TYPE != 1
        THEN CASE
             WHEN T.TO_CONTAINER_TYPE = 3
               THEN 'PKG-' || PK2.ID
             WHEN T.TO_CONTAINER_TYPE = 2
               THEN P2.PRODUCT_NUMBER || '{' || PS.SERIAL_NUMBER || '}'
             END
      ELSE B2.ZONE || '-' || B2.POSITION || '-' || B2.SHELF
      END                                  AS TO_BIN,

      B2.ZONE                              AS TO_BIN_ZONE,

      P.PRODUCT_TYPE,

      /* DEFINING FROM AND TO CONTAINER TYPES */
      CASE
      WHEN T.FROM_CONTAINER_TYPE = 1
        THEN 'BIN'
      WHEN T.FROM_CONTAINER_TYPE = 2
        THEN 'KIT'
      WHEN T.FROM_CONTAINER_TYPE = 3
        THEN 'PACKAGE'
      WHEN T.FROM_CONTAINER_TYPE = 4
        THEN 'LOAN'
      END                                  AS FROM_CONTAINER,

      CASE
      WHEN T.TO_CONTAINER_TYPE = 1
        THEN 'BIN'
      WHEN T.TO_CONTAINER_TYPE = 2
        THEN 'KIT'
      WHEN T.TO_CONTAINER_TYPE = 3
        THEN 'PACKAGE'
      WHEN T.TO_CONTAINER_TYPE = 4
        THEN 'LOAN'
      END                                  AS TO_CONTAINER
    FROM
      SMS_WRITE.TRANSFER T
      LEFT JOIN SMS_WRITE.PRODUCT P ON T.PRODUCT_ID = P.ID
      LEFT JOIN SMS_WRITE.PACKAGE PK ON T.FROM_CONTAINER_ID = PK.ID
      LEFT JOIN SMS_WRITE.PACKAGE PK2 ON T.TO_CONTAINER_ID = PK2.ID
      LEFT JOIN SMS_WRITE.STOCK S ON S.ID = T.FROM_STOCK_ID
      LEFT JOIN SMS_WRITE.PRODUCT P2 ON T.TO_KIT_PRODUCT_ID = P2.ID
      LEFT JOIN SMS_WRITE.PRODUCT_SERIAL PS ON T.TO_KIT_SERIAL_ID = PS.ID
      LEFT JOIN SMS_WRITE.USER_TABLE U ON U.ID = T.ASSIGNED_USER_ID
      LEFT JOIN SMS_WRITE.EMPLOYEE EM ON EM.USER_ID = U.ID
      LEFT JOIN SMS_WRITE.BIN B ON T.FROM_CONTAINER_ID = B.ID
      LEFT JOIN SMS_WRITE.BIN B2 ON T.TO_CONTAINER_ID = B2.ID
    WHERE
      T.LOCATION_TYPE = 1
      AND T.LOCATION_ID = 370
      AND T.STATUS = 2
      AND TO_CHAR(T.COMPLETED_DATE - 5 / 24, 'MM-DD-YYYY') = TO_CHAR(CURRENT_DATE - 5 / 24, 'MM-DD-YYYY')
      AND T.CREATED_DATE > CURRENT_DATE - 14
      AND EM.FIRST_NAME || ' ' || EM.LAST_NAME IN (
        'LAKESHIA LIGGINS',
        'ROLANDO FLORES',
        'FELECIA TUGGLE',
        'SAM THOMAS',
        'NICHOLAS THOMAS',
        'CYNTHIA SCOTT',
        'RAYSHALINA PETTIGREW',
        'THIOUBALO SY',
        'TIFFANY THOMAS',
        'SHANIKA MCCRAVEN',
        'GONZLA JOYNER',
        'JAMES SULLIVAN',
        'NORMA CISNEROS',
        'JACQUELINE LOPEZ',
        'KASEY WILSON',
        'MICHAEL PRICE',
        'JEFFERY ROBINSON'
      )
    GROUP BY
      EM.SITE_ID,
      P.PRODUCT_TYPE,
      P2.PRODUCT_NUMBER,
      PS.SERIAL_NUMBER,
      T.TRANSFER_TYPE,
      U.ID,
      T.ID,
      PK.ID, PK2.ID,
      B.ID, B2.ID,
      T.CREATED_DATE,
      T.COMPLETED_DATE,
      PK.STATUS, PK2.STATUS,
      EM.FIRST_NAME, EM.LAST_NAME,
      B.ZONE, B.SHELF, B.POSITION,
      B2.ZONE, B2.SHELF, B2.POSITION,
      T.FROM_CONTAINER_TYPE, T.TO_CONTAINER_TYPE
    ORDER BY
      T.COMPLETED_DATE
),
    TRANSFER_DEFINITIONS AS (
      SELECT
        TRANSFER_NUMBER,
        TRANSFER_TYPE,
        EMPLOYEE_USER AS EMPLOYEE,
        /* DEFINE TYPE OF TRANSFER */
        CASE
        -- PIECE INBOUND TRANSFERS
        WHEN TRANSFER_TYPE = ANY (6, 7, 10, 20, 21, 23) AND PRODUCT_TYPE = 0
          THEN 'PIECE_INBOUND_TRANSFER'
        -- KIT INBOUND TRANSFERS
        WHEN TRANSFER_TYPE = ANY (6, 7, 10, 20, 21, 23) AND PRODUCT_TYPE = 1
          THEN 'KIT_INBOUND_TRANSFER'
        -- INSTRUMENT INBOUND TRANSFERS
        WHEN TRANSFER_TYPE = ANY (6, 7, 10, 20, 21, 23) AND PRODUCT_TYPE = 3
          THEN 'INSTRUMENT_INBOUND_TRANSFER'
        /* PUT AWAY TRANSFERS, SET TO ONLY CAPTURE TRANSFERS FROM NEW KIT ASSEMBLY OR VEHICLES */
        WHEN TRANSFER_TYPE = ANY (2, 17, 14) AND TO_BIN_ZONE IS NOT NULL AND
             REGEXP_LIKE(FROM_BIN_ZONE, '^(Vehicle\s\d|New Kit Assembly)')
          THEN 'PUTAWAY_TRANSFER'
        /* PUT AWAY TRANSFERS FROM PACKAGES TO BIN, FOR THE RARE CASE A PACKAGE IS NOT SHIPPED */
        WHEN TRANSFER_TYPE = ANY (6, 20) AND REGEXP_LIKE(TO_BIN_ZONE, '(G\d|R\d|I\d)')
          THEN 'PUTAWAY_TRANSFER'
        -- KIT BUILDS
        WHEN TRANSFER_TYPE = ANY (1, 13)
          THEN 'KIT_BUILD_TRANSFER'
        -- OUTBOUND TRANSFER
        WHEN TRANSFER_TYPE = ANY (3, 7, 18, 21)
          THEN 'OUTBOUND_TRANSFER'
        ELSE 'OTHER_TRANSFERS'
        END           AS TYPE_OF_TRANSFER
      FROM
        TRANSFERS
  ),
    TRANSFERS_BY_DEFINED_TYPE AS (
      SELECT DISTINCT
        TD.EMPLOYEE,
        TD.TYPE_OF_TRANSFER,
        COUNT(TD.TYPE_OF_TRANSFER) AS NUMBER_BY_TYPE
      FROM
        TRANSFER_DEFINITIONS TD
      GROUP BY
        TD.EMPLOYEE,
        TD.TYPE_OF_TRANSFER
  ),
    TRANSPOSED_DATA AS (
      SELECT
        EMPLOYEE,
        MAX(CASE WHEN TYPE_OF_TRANSFER = 'KIT_INBOUND_TRANSFER'
          THEN NUMBER_BY_TYPE
            ELSE 0 END) AS KIT_INBOUND_TRANSFER,

        MAX(CASE WHEN TYPE_OF_TRANSFER = 'PIECE_INBOUND_TRANSFER'
          THEN NUMBER_BY_TYPE
            ELSE 0 END) AS PIECE_INBOUND_TRANSFER,

        MAX(CASE WHEN TYPE_OF_TRANSFER = 'INSTRUMENT_INBOUND_TRANSFER'
          THEN NUMBER_BY_TYPE
            ELSE 0 END) AS INSTRUMENT_INBOUND_TRANSFER,

        MAX(CASE WHEN TYPE_OF_TRANSFER = 'PUTAWAY_TRANSFER'
          THEN NUMBER_BY_TYPE
            ELSE 0 END) AS PUTAWAY_TRANSFER,

        MAX(CASE WHEN TYPE_OF_TRANSFER = 'KIT_BUILD_TRANSFER'
          THEN NUMBER_BY_TYPE
            ELSE 0 END) AS KIT_BUILD_TRANSFER,

        MAX(CASE WHEN TYPE_OF_TRANSFER = 'OUTBOUND_TRANSFER'
          THEN NUMBER_BY_TYPE
            ELSE 0 END) AS OUTBOUND_TRANSFER,

        MAX(CASE WHEN TYPE_OF_TRANSFER = 'OTHER_TRANSFERS'
          THEN NUMBER_BY_TYPE
            ELSE 0 END) AS OTHER_TRANSFER
      FROM
        TRANSFERS_BY_DEFINED_TYPE
      GROUP BY
        EMPLOYEE
  ),
    EMPLOYEE_PRODUCTIVITY AS (
      SELECT
        EMPLOYEE,

        KIT_INBOUND_TRANSFER,
        ROUND((KIT_INBOUND_TRANSFER / 6.85) / (60 / 4), 2)         AS KIT_INBOUND_PROD,

        PIECE_INBOUND_TRANSFER,
        ROUND((PIECE_INBOUND_TRANSFER / 6.85) / (60 / 0.25), 2)    AS PIECE_INBOUND_PROD,

        INSTRUMENT_INBOUND_TRANSFER,
        ROUND((INSTRUMENT_INBOUND_TRANSFER / 6.85) / (60 / 15), 2) AS INSTRUMENT_INBOUND_PROD,

        PUTAWAY_TRANSFER,
        ROUND((PUTAWAY_TRANSFER / 6.85) / (60 / 1), 2)             AS PUTAWAY_PROD,

        KIT_BUILD_TRANSFER,
        ROUND((KIT_BUILD_TRANSFER / 6.85) / (60 / 3), 2)           AS KIT_BUILD_PROD,

        OUTBOUND_TRANSFER,
        ROUND((OUTBOUND_TRANSFER / 6.85) / (60 / 2.5), 2)          AS OUTBOUND_PROD,

        OTHER_TRANSFER,
        ROUND(((OTHER_TRANSFER * 100) / (
          KIT_BUILD_TRANSFER + KIT_INBOUND_TRANSFER + PIECE_INBOUND_TRANSFER + INSTRUMENT_INBOUND_TRANSFER +
          OUTBOUND_TRANSFER
          + PUTAWAY_TRANSFER + OTHER_TRANSFER)) / 100, 2)                 AS OTHER_PROD

      FROM
        TRANSPOSED_DATA
  )
SELECT
  EMPLOYEE,
  KIT_INBOUND_TRANSFER,
  PIECE_INBOUND_TRANSFER,
  INSTRUMENT_INBOUND_TRANSFER,
  PUTAWAY_TRANSFER,
  KIT_BUILD_TRANSFER,
  OUTBOUND_TRANSFER,
  OTHER_TRANSFER,
  (KIT_INBOUND_PROD + PIECE_INBOUND_PROD + INSTRUMENT_INBOUND_PROD + PUTAWAY_PROD + KIT_BUILD_PROD + OUTBOUND_PROD +
   OTHER_PROD) AS TOTAL_PRODUCTIVITY
FROM
  EMPLOYEE_PRODUCTIVITY