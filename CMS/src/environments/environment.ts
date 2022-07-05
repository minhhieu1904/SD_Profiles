const protocol: string = window.location.protocol;
const hostname: string = window.location.hostname;
const port: string = ':7009';
const ip: string = `${hostname}${port}`;
const baseUrl: string = `https://${ip}`;

export const environment = {
  production: true,
  firebase: {
    apiKey: "Your Api Key",
    authDomain: "Your Auth Domain",
    databaseURL: "Your Database Url",
    projectId: "Your Project Id",
    storageBucket: "Your StorageBucket url",
    messagingSenderId: "Your Sender Id"
  },
  apiUrl: `${baseUrl}/api/`,
  baseUrl: `${baseUrl}/`,
  imageUserDefault: 'assets/images/user/user.png'
};
