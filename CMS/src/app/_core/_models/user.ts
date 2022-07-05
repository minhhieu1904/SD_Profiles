import { Role } from "./role";

export interface User {
    userId: string;
    name: string;
    avatar: string;
    isEnabled: boolean;
    isDelete: boolean;
    userName: string;
    email: string;
    phoneNumber: string;
    password: string;
    newPassword: string;
    roles: Role[];
}