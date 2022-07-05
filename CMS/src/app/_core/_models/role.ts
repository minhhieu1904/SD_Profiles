export interface Role {
    id: string;
    name: string;
    isActive: boolean;
}

export interface RolesUser {
    userName: string;
    roles: Role[];
}