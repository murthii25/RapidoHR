import { Guid } from "guid-typescript";

export class Payroll {    
        EmpPRID: Guid | null;
        EmpID : Guid | null;
        basic: number | null;
        DA: number | null;
        HRA: number | null;
        conveyance: number | null;
        Adhoc_allow: number | null;
        PF_by_bank: number | null;
        PF_by_emp: number | null;
        Professional_tax: number | null;
        Festival_advance: number | null;
        HG_Insurance: boolean | null;
        LIC: boolean | null;
        Net_Pay: number | null;
        Date_created: Date | null;
        Createdby: string;
    }
