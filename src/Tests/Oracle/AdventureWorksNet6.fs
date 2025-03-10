// This code was generated by `SqlHydra.Oracle` -- v2.0.1.0.
namespace Oracle.AdventureWorksNet6


[<AutoOpen>]
module ColumnReaders =
    type Column(reader: System.Data.IDataReader, getOrdinal: string -> int, column) =
            member __.Name = column
            member __.IsNull() = getOrdinal column |> reader.IsDBNull
            override __.ToString() = __.Name

    type RequiredColumn<'T, 'Reader when 'Reader :> System.Data.IDataReader>(reader: 'Reader, getOrdinal, getter: int -> 'T, column) =
            inherit Column(reader, getOrdinal, column)
            member __.Read(?alias) = alias |> Option.defaultValue __.Name |> getOrdinal |> getter

    type OptionalColumn<'T, 'Reader when 'Reader :> System.Data.IDataReader>(reader: 'Reader, getOrdinal, getter: int -> 'T, column) =
            inherit Column(reader, getOrdinal, column)
            member __.Read(?alias) = 
                match alias |> Option.defaultValue __.Name |> getOrdinal with
                | o when reader.IsDBNull o -> None
                | o -> Some (getter o)

[<AutoOpen>]
module private DataReaderExtensions =
    type System.Data.IDataReader with
        member reader.GetDateOnly(ordinal: int) = 
            reader.GetDateTime(ordinal) |> System.DateOnly.FromDateTime
    
    type System.Data.Common.DbDataReader with
        member reader.GetTimeOnly(ordinal: int) = 
            reader.GetFieldValue(ordinal) |> System.TimeOnly.FromTimeSpan
        

module OT =
    [<CLIMutable>]
    type CONTACTS =
        { CONTACT_ID: int64
          CUSTOMER_ID: Option<int64>
          EMAIL: string
          FIRST_NAME: string
          LAST_NAME: string
          PHONE: Option<string> }

    let CONTACTS = SqlHydra.Query.Table.table<CONTACTS>

    [<CLIMutable>]
    type COUNTRIES =
        { COUNTRY_ID: string
          COUNTRY_NAME: string
          REGION_ID: Option<int64> }

    let COUNTRIES = SqlHydra.Query.Table.table<COUNTRIES>

    [<CLIMutable>]
    type CUSTOMERS =
        { ADDRESS: Option<string>
          CREDIT_LIMIT: Option<decimal>
          CUSTOMER_ID: int64
          NAME: string
          WEBSITE: Option<string> }

    let CUSTOMERS = SqlHydra.Query.Table.table<CUSTOMERS>

    [<CLIMutable>]
    type EMPLOYEES =
        { EMAIL: string
          EMPLOYEE_ID: int64
          FIRST_NAME: string
          HIRE_DATE: System.DateTime
          JOB_TITLE: string
          LAST_NAME: string
          MANAGER_ID: Option<int64>
          PHONE: string }

    let EMPLOYEES = SqlHydra.Query.Table.table<EMPLOYEES>

    [<CLIMutable>]
    type INVENTORIES =
        { PRODUCT_ID: int64
          QUANTITY: int
          WAREHOUSE_ID: int64 }

    let INVENTORIES = SqlHydra.Query.Table.table<INVENTORIES>

    [<CLIMutable>]
    type LOCATIONS =
        { ADDRESS: string
          CITY: Option<string>
          COUNTRY_ID: Option<string>
          LOCATION_ID: int64
          POSTAL_CODE: Option<string>
          STATE: Option<string> }

    let LOCATIONS = SqlHydra.Query.Table.table<LOCATIONS>

    [<CLIMutable>]
    type ORDERS =
        { CUSTOMER_ID: int64
          ORDER_DATE: System.DateTime
          ORDER_ID: int64
          SALESMAN_ID: Option<int64>
          STATUS: string }

    let ORDERS = SqlHydra.Query.Table.table<ORDERS>

    [<CLIMutable>]
    type ORDER_ITEMS =
        { ITEM_ID: int64
          ORDER_ID: int64
          PRODUCT_ID: int64
          QUANTITY: int
          UNIT_PRICE: decimal }

    let ORDER_ITEMS = SqlHydra.Query.Table.table<ORDER_ITEMS>

    [<CLIMutable>]
    type PRODUCTS =
        { CATEGORY_ID: int64
          DESCRIPTION: Option<string>
          LIST_PRICE: Option<decimal>
          PRODUCT_ID: int64
          PRODUCT_NAME: string
          STANDARD_COST: Option<decimal> }

    let PRODUCTS = SqlHydra.Query.Table.table<PRODUCTS>

    [<CLIMutable>]
    type PRODUCT_CATEGORIES =
        { CATEGORY_ID: int64
          CATEGORY_NAME: string }

    let PRODUCT_CATEGORIES = SqlHydra.Query.Table.table<PRODUCT_CATEGORIES>

    [<CLIMutable>]
    type REGIONS =
        { REGION_ID: int64
          REGION_NAME: string }

    let REGIONS = SqlHydra.Query.Table.table<REGIONS>

    [<CLIMutable>]
    type WAREHOUSES =
        { LOCATION_ID: Option<int64>
          WAREHOUSE_ID: int64
          WAREHOUSE_NAME: Option<string> }

    let WAREHOUSES = SqlHydra.Query.Table.table<WAREHOUSES>

    module Readers =
        type CONTACTSReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.CONTACT_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "CONTACT_ID")
            member __.CUSTOMER_ID = OptionalColumn(reader, getOrdinal, reader.GetInt64, "CUSTOMER_ID")
            member __.EMAIL = RequiredColumn(reader, getOrdinal, reader.GetString, "EMAIL")
            member __.FIRST_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "FIRST_NAME")
            member __.LAST_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "LAST_NAME")
            member __.PHONE = OptionalColumn(reader, getOrdinal, reader.GetString, "PHONE")

            member __.Read() =
                { CONTACTS.CONTACT_ID = __.CONTACT_ID.Read()
                  CUSTOMER_ID = __.CUSTOMER_ID.Read()
                  EMAIL = __.EMAIL.Read()
                  FIRST_NAME = __.FIRST_NAME.Read()
                  LAST_NAME = __.LAST_NAME.Read()
                  PHONE = __.PHONE.Read() }

            member __.ReadIfNotNull() =
                if __.CONTACT_ID.IsNull() then None else Some(__.Read())

        type COUNTRIESReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.COUNTRY_ID = RequiredColumn(reader, getOrdinal, reader.GetString, "COUNTRY_ID")
            member __.COUNTRY_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "COUNTRY_NAME")
            member __.REGION_ID = OptionalColumn(reader, getOrdinal, reader.GetInt64, "REGION_ID")

            member __.Read() =
                { COUNTRIES.COUNTRY_ID = __.COUNTRY_ID.Read()
                  COUNTRY_NAME = __.COUNTRY_NAME.Read()
                  REGION_ID = __.REGION_ID.Read() }

            member __.ReadIfNotNull() =
                if __.COUNTRY_ID.IsNull() then None else Some(__.Read())

        type CUSTOMERSReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.ADDRESS = OptionalColumn(reader, getOrdinal, reader.GetString, "ADDRESS")
            member __.CREDIT_LIMIT = OptionalColumn(reader, getOrdinal, reader.GetDecimal, "CREDIT_LIMIT")
            member __.CUSTOMER_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "CUSTOMER_ID")
            member __.NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "NAME")
            member __.WEBSITE = OptionalColumn(reader, getOrdinal, reader.GetString, "WEBSITE")

            member __.Read() =
                { CUSTOMERS.ADDRESS = __.ADDRESS.Read()
                  CREDIT_LIMIT = __.CREDIT_LIMIT.Read()
                  CUSTOMER_ID = __.CUSTOMER_ID.Read()
                  NAME = __.NAME.Read()
                  WEBSITE = __.WEBSITE.Read() }

            member __.ReadIfNotNull() =
                if __.CUSTOMER_ID.IsNull() then None else Some(__.Read())

        type EMPLOYEESReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.EMAIL = RequiredColumn(reader, getOrdinal, reader.GetString, "EMAIL")
            member __.EMPLOYEE_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "EMPLOYEE_ID")
            member __.FIRST_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "FIRST_NAME")
            member __.HIRE_DATE = RequiredColumn(reader, getOrdinal, reader.GetDateTime, "HIRE_DATE")
            member __.JOB_TITLE = RequiredColumn(reader, getOrdinal, reader.GetString, "JOB_TITLE")
            member __.LAST_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "LAST_NAME")
            member __.MANAGER_ID = OptionalColumn(reader, getOrdinal, reader.GetInt64, "MANAGER_ID")
            member __.PHONE = RequiredColumn(reader, getOrdinal, reader.GetString, "PHONE")

            member __.Read() =
                { EMPLOYEES.EMAIL = __.EMAIL.Read()
                  EMPLOYEE_ID = __.EMPLOYEE_ID.Read()
                  FIRST_NAME = __.FIRST_NAME.Read()
                  HIRE_DATE = __.HIRE_DATE.Read()
                  JOB_TITLE = __.JOB_TITLE.Read()
                  LAST_NAME = __.LAST_NAME.Read()
                  MANAGER_ID = __.MANAGER_ID.Read()
                  PHONE = __.PHONE.Read() }

            member __.ReadIfNotNull() =
                if __.EMPLOYEE_ID.IsNull() then None else Some(__.Read())

        type INVENTORIESReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.PRODUCT_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "PRODUCT_ID")
            member __.QUANTITY = RequiredColumn(reader, getOrdinal, reader.GetInt32, "QUANTITY")
            member __.WAREHOUSE_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "WAREHOUSE_ID")

            member __.Read() =
                { INVENTORIES.PRODUCT_ID = __.PRODUCT_ID.Read()
                  QUANTITY = __.QUANTITY.Read()
                  WAREHOUSE_ID = __.WAREHOUSE_ID.Read() }

            member __.ReadIfNotNull() =
                if __.PRODUCT_ID.IsNull() then None else Some(__.Read())

        type LOCATIONSReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.ADDRESS = RequiredColumn(reader, getOrdinal, reader.GetString, "ADDRESS")
            member __.CITY = OptionalColumn(reader, getOrdinal, reader.GetString, "CITY")
            member __.COUNTRY_ID = OptionalColumn(reader, getOrdinal, reader.GetString, "COUNTRY_ID")
            member __.LOCATION_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "LOCATION_ID")
            member __.POSTAL_CODE = OptionalColumn(reader, getOrdinal, reader.GetString, "POSTAL_CODE")
            member __.STATE = OptionalColumn(reader, getOrdinal, reader.GetString, "STATE")

            member __.Read() =
                { LOCATIONS.ADDRESS = __.ADDRESS.Read()
                  CITY = __.CITY.Read()
                  COUNTRY_ID = __.COUNTRY_ID.Read()
                  LOCATION_ID = __.LOCATION_ID.Read()
                  POSTAL_CODE = __.POSTAL_CODE.Read()
                  STATE = __.STATE.Read() }

            member __.ReadIfNotNull() =
                if __.LOCATION_ID.IsNull() then None else Some(__.Read())

        type ORDERSReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.CUSTOMER_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "CUSTOMER_ID")
            member __.ORDER_DATE = RequiredColumn(reader, getOrdinal, reader.GetDateTime, "ORDER_DATE")
            member __.ORDER_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "ORDER_ID")
            member __.SALESMAN_ID = OptionalColumn(reader, getOrdinal, reader.GetInt64, "SALESMAN_ID")
            member __.STATUS = RequiredColumn(reader, getOrdinal, reader.GetString, "STATUS")

            member __.Read() =
                { ORDERS.CUSTOMER_ID = __.CUSTOMER_ID.Read()
                  ORDER_DATE = __.ORDER_DATE.Read()
                  ORDER_ID = __.ORDER_ID.Read()
                  SALESMAN_ID = __.SALESMAN_ID.Read()
                  STATUS = __.STATUS.Read() }

            member __.ReadIfNotNull() =
                if __.ORDER_ID.IsNull() then None else Some(__.Read())

        type ORDER_ITEMSReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.ITEM_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "ITEM_ID")
            member __.ORDER_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "ORDER_ID")
            member __.PRODUCT_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "PRODUCT_ID")
            member __.QUANTITY = RequiredColumn(reader, getOrdinal, reader.GetInt32, "QUANTITY")
            member __.UNIT_PRICE = RequiredColumn(reader, getOrdinal, reader.GetDecimal, "UNIT_PRICE")

            member __.Read() =
                { ORDER_ITEMS.ITEM_ID = __.ITEM_ID.Read()
                  ORDER_ID = __.ORDER_ID.Read()
                  PRODUCT_ID = __.PRODUCT_ID.Read()
                  QUANTITY = __.QUANTITY.Read()
                  UNIT_PRICE = __.UNIT_PRICE.Read() }

            member __.ReadIfNotNull() =
                if __.ITEM_ID.IsNull() then None else Some(__.Read())

        type PRODUCTSReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.CATEGORY_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "CATEGORY_ID")
            member __.DESCRIPTION = OptionalColumn(reader, getOrdinal, reader.GetString, "DESCRIPTION")
            member __.LIST_PRICE = OptionalColumn(reader, getOrdinal, reader.GetDecimal, "LIST_PRICE")
            member __.PRODUCT_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "PRODUCT_ID")
            member __.PRODUCT_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "PRODUCT_NAME")
            member __.STANDARD_COST = OptionalColumn(reader, getOrdinal, reader.GetDecimal, "STANDARD_COST")

            member __.Read() =
                { PRODUCTS.CATEGORY_ID = __.CATEGORY_ID.Read()
                  DESCRIPTION = __.DESCRIPTION.Read()
                  LIST_PRICE = __.LIST_PRICE.Read()
                  PRODUCT_ID = __.PRODUCT_ID.Read()
                  PRODUCT_NAME = __.PRODUCT_NAME.Read()
                  STANDARD_COST = __.STANDARD_COST.Read() }

            member __.ReadIfNotNull() =
                if __.PRODUCT_ID.IsNull() then None else Some(__.Read())

        type PRODUCT_CATEGORIESReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.CATEGORY_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "CATEGORY_ID")
            member __.CATEGORY_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "CATEGORY_NAME")

            member __.Read() =
                { PRODUCT_CATEGORIES.CATEGORY_ID = __.CATEGORY_ID.Read()
                  CATEGORY_NAME = __.CATEGORY_NAME.Read() }

            member __.ReadIfNotNull() =
                if __.CATEGORY_ID.IsNull() then None else Some(__.Read())

        type REGIONSReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.REGION_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "REGION_ID")
            member __.REGION_NAME = RequiredColumn(reader, getOrdinal, reader.GetString, "REGION_NAME")

            member __.Read() =
                { REGIONS.REGION_ID = __.REGION_ID.Read()
                  REGION_NAME = __.REGION_NAME.Read() }

            member __.ReadIfNotNull() =
                if __.REGION_ID.IsNull() then None else Some(__.Read())

        type WAREHOUSESReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader, getOrdinal) =
            member __.LOCATION_ID = OptionalColumn(reader, getOrdinal, reader.GetInt64, "LOCATION_ID")
            member __.WAREHOUSE_ID = RequiredColumn(reader, getOrdinal, reader.GetInt64, "WAREHOUSE_ID")
            member __.WAREHOUSE_NAME = OptionalColumn(reader, getOrdinal, reader.GetString, "WAREHOUSE_NAME")

            member __.Read() =
                { WAREHOUSES.LOCATION_ID = __.LOCATION_ID.Read()
                  WAREHOUSE_ID = __.WAREHOUSE_ID.Read()
                  WAREHOUSE_NAME = __.WAREHOUSE_NAME.Read() }

            member __.ReadIfNotNull() =
                if __.WAREHOUSE_ID.IsNull() then None else Some(__.Read())

type HydraReader(reader: Oracle.ManagedDataAccess.Client.OracleDataReader) =
    let mutable accFieldCount = 0
    let buildGetOrdinal fieldCount =
        let dictionary = 
            [0..reader.FieldCount-1] 
            |> List.map (fun i -> reader.GetName(i), i)
            |> List.sortBy snd
            |> List.skip accFieldCount
            |> List.take fieldCount
            |> dict
        accFieldCount <- accFieldCount + fieldCount
        fun col -> dictionary.Item col
        
    let lazyOTCONTACTS = lazy (OT.Readers.CONTACTSReader(reader, buildGetOrdinal 6))
    let lazyOTCOUNTRIES = lazy (OT.Readers.COUNTRIESReader(reader, buildGetOrdinal 3))
    let lazyOTCUSTOMERS = lazy (OT.Readers.CUSTOMERSReader(reader, buildGetOrdinal 5))
    let lazyOTEMPLOYEES = lazy (OT.Readers.EMPLOYEESReader(reader, buildGetOrdinal 8))
    let lazyOTINVENTORIES = lazy (OT.Readers.INVENTORIESReader(reader, buildGetOrdinal 3))
    let lazyOTLOCATIONS = lazy (OT.Readers.LOCATIONSReader(reader, buildGetOrdinal 6))
    let lazyOTORDERS = lazy (OT.Readers.ORDERSReader(reader, buildGetOrdinal 5))
    let lazyOTORDER_ITEMS = lazy (OT.Readers.ORDER_ITEMSReader(reader, buildGetOrdinal 5))
    let lazyOTPRODUCTS = lazy (OT.Readers.PRODUCTSReader(reader, buildGetOrdinal 6))
    let lazyOTPRODUCT_CATEGORIES = lazy (OT.Readers.PRODUCT_CATEGORIESReader(reader, buildGetOrdinal 2))
    let lazyOTREGIONS = lazy (OT.Readers.REGIONSReader(reader, buildGetOrdinal 2))
    let lazyOTWAREHOUSES = lazy (OT.Readers.WAREHOUSESReader(reader, buildGetOrdinal 3))
    member __.``OT.CONTACTS`` = lazyOTCONTACTS.Value
    member __.``OT.COUNTRIES`` = lazyOTCOUNTRIES.Value
    member __.``OT.CUSTOMERS`` = lazyOTCUSTOMERS.Value
    member __.``OT.EMPLOYEES`` = lazyOTEMPLOYEES.Value
    member __.``OT.INVENTORIES`` = lazyOTINVENTORIES.Value
    member __.``OT.LOCATIONS`` = lazyOTLOCATIONS.Value
    member __.``OT.ORDERS`` = lazyOTORDERS.Value
    member __.``OT.ORDER_ITEMS`` = lazyOTORDER_ITEMS.Value
    member __.``OT.PRODUCTS`` = lazyOTPRODUCTS.Value
    member __.``OT.PRODUCT_CATEGORIES`` = lazyOTPRODUCT_CATEGORIES.Value
    member __.``OT.REGIONS`` = lazyOTREGIONS.Value
    member __.``OT.WAREHOUSES`` = lazyOTWAREHOUSES.Value
    member private __.AccFieldCount with get () = accFieldCount and set (value) = accFieldCount <- value

    member private __.GetReaderByName(entity: string, isOption: bool) =
        match entity, isOption with
        | "OT.CONTACTS", false -> __.``OT.CONTACTS``.Read >> box
        | "OT.CONTACTS", true -> __.``OT.CONTACTS``.ReadIfNotNull >> box
        | "OT.COUNTRIES", false -> __.``OT.COUNTRIES``.Read >> box
        | "OT.COUNTRIES", true -> __.``OT.COUNTRIES``.ReadIfNotNull >> box
        | "OT.CUSTOMERS", false -> __.``OT.CUSTOMERS``.Read >> box
        | "OT.CUSTOMERS", true -> __.``OT.CUSTOMERS``.ReadIfNotNull >> box
        | "OT.EMPLOYEES", false -> __.``OT.EMPLOYEES``.Read >> box
        | "OT.EMPLOYEES", true -> __.``OT.EMPLOYEES``.ReadIfNotNull >> box
        | "OT.INVENTORIES", false -> __.``OT.INVENTORIES``.Read >> box
        | "OT.INVENTORIES", true -> __.``OT.INVENTORIES``.ReadIfNotNull >> box
        | "OT.LOCATIONS", false -> __.``OT.LOCATIONS``.Read >> box
        | "OT.LOCATIONS", true -> __.``OT.LOCATIONS``.ReadIfNotNull >> box
        | "OT.ORDERS", false -> __.``OT.ORDERS``.Read >> box
        | "OT.ORDERS", true -> __.``OT.ORDERS``.ReadIfNotNull >> box
        | "OT.ORDER_ITEMS", false -> __.``OT.ORDER_ITEMS``.Read >> box
        | "OT.ORDER_ITEMS", true -> __.``OT.ORDER_ITEMS``.ReadIfNotNull >> box
        | "OT.PRODUCTS", false -> __.``OT.PRODUCTS``.Read >> box
        | "OT.PRODUCTS", true -> __.``OT.PRODUCTS``.ReadIfNotNull >> box
        | "OT.PRODUCT_CATEGORIES", false -> __.``OT.PRODUCT_CATEGORIES``.Read >> box
        | "OT.PRODUCT_CATEGORIES", true -> __.``OT.PRODUCT_CATEGORIES``.ReadIfNotNull >> box
        | "OT.REGIONS", false -> __.``OT.REGIONS``.Read >> box
        | "OT.REGIONS", true -> __.``OT.REGIONS``.ReadIfNotNull >> box
        | "OT.WAREHOUSES", false -> __.``OT.WAREHOUSES``.Read >> box
        | "OT.WAREHOUSES", true -> __.``OT.WAREHOUSES``.ReadIfNotNull >> box
        | _ -> failwith $"Could not read type '{entity}' because no generated reader exists."

    static member private GetPrimitiveReader(t: System.Type, reader: Oracle.ManagedDataAccess.Client.OracleDataReader, isOpt: bool) =
        let wrap get (ord: int) = 
            if isOpt 
            then (if reader.IsDBNull ord then None else get ord |> Some) |> box 
            else get ord |> box 
        

        if t = typedefof<int> then Some(wrap reader.GetInt32)
        else if t = typedefof<int64> then Some(wrap reader.GetInt64)
        else if t = typedefof<decimal> then Some(wrap reader.GetDecimal)
        else if t = typedefof<double> then Some(wrap reader.GetDouble)
        else if t = typedefof<System.Single> then Some(wrap reader.GetFieldValue)
        else if t = typedefof<string> then Some(wrap reader.GetString)
        else if t = typedefof<System.DateTime> then Some(wrap reader.GetDateTime)
        else if t = typedefof<System.TimeSpan> then Some(wrap reader.GetTimeSpan)
        else if t = typedefof<byte []> then Some(wrap reader.GetFieldValue<byte []>)
        else None

    static member Read(reader: Oracle.ManagedDataAccess.Client.OracleDataReader) = 
        let hydra = HydraReader(reader)
        reader.SuppressGetDecimalInvalidCastException <- true            
        let getOrdinalAndIncrement() = 
            let ordinal = hydra.AccFieldCount
            hydra.AccFieldCount <- hydra.AccFieldCount + 1
            ordinal
            
        let buildEntityReadFn (t: System.Type) = 
            let t, isOpt = 
                if t.IsGenericType && t.GetGenericTypeDefinition() = typedefof<Option<_>> 
                then t.GenericTypeArguments.[0], true
                else t, false
            
            match HydraReader.GetPrimitiveReader(t, reader, isOpt) with
            | Some primitiveReader -> 
                let ord = getOrdinalAndIncrement()
                fun () -> primitiveReader ord
            | None ->
                let nameParts = t.FullName.Split([| '.'; '+' |])
                let schemaAndType = nameParts |> Array.skip (nameParts.Length - 2) |> fun parts -> System.String.Join(".", parts)
                hydra.GetReaderByName(schemaAndType, isOpt)
            
        // Return a fn that will hydrate 'T (which may be a tuple)
        // This fn will be called once per each record returned by the data reader.
        let t = typeof<'T>
        if FSharp.Reflection.FSharpType.IsTuple(t) then
            let readEntityFns = FSharp.Reflection.FSharpType.GetTupleElements(t) |> Array.map buildEntityReadFn
            fun () ->
                let entities = readEntityFns |> Array.map (fun read -> read())
                Microsoft.FSharp.Reflection.FSharpValue.MakeTuple(entities, t) :?> 'T
        else
            let readEntityFn = t |> buildEntityReadFn
            fun () -> 
                readEntityFn() :?> 'T
        
