export interface Contact {
    id: number;
    name: string;
    subject: string;
    email: string;
    phone: string;
    message: string;
    status: boolean | null;
    create_By: string;
    create_Time: string | null;
    update_By: string;
    update_Time: string | null;
}