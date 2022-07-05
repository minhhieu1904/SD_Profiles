export interface Member {
    id: number;
    name: string;
    address: string;
    phone: string;
    email: string;
    avatar: string;
    description: string;
    skill: string;
    position_Id: number | null;
    status: boolean | null;
    create_By: string;
    create_Time: string | null;
    update_By: string;
    update_Time: string | null;
    position_Name: string;
}