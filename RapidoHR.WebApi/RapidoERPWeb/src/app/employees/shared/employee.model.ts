import { Guid } from "guid-typescript";

export class Employee {
        EmpID: Guid;
        EmpCode: string;
        FirstName: string;
        MiddleName: string;
        LastName: string;
        Gender: string;
        Nationality: string;
        Designation: string;
        Address: string;
        EmailId: string;
        ContactNo: number | null;
        DateCreated: Date | string | null;
        Createdby: string;
}
