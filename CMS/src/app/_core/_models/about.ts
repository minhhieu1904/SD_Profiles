export interface About {
    id: number;
    title: string;
    content: string;
    description: string;
    image: string;
    address: string;
    phone: string;
    email: string;
    isDefault: boolean | null;
    status: boolean | null;
    create_By: string;
    create_Time: string | null;
    update_By: string;
    update_Time: string | null;
}