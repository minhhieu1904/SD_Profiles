export interface ApplicationUser {
    name: string;
    userName: string;
    normalizedUserName: string;
    userType: string;
    isEnabled: boolean;
    isDelete: boolean;
    adAccountMapping: string;
    id: string;
    email: string;
    normalizedEmail: string;
    emailConfirmed: boolean;
    passwordHash: string;
    securityStamp: string;
    concurrencyStamp: string;
    phoneNumber: string;
    phoneNumberConfirmed: boolean;
    twoFactorEnabled: boolean;
    lockoutEnd: string;
    lockoutEnabled: boolean;
    accessFailedCount: number;
}