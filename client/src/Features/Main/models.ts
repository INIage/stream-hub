export interface LoginResponce {
  success: boolean;
  user: User;
}

export interface User {
  id: number;
  username: string;
  avatar: string;
  token: string;
  channel: Channel;
  settings: {
    chat: Chat;
    beta: {
      [key: string]: number;
    };
  };
  dialogs: number;
  bl: boolean;
  bl_data: [];
  rights: string;
  premium: boolean;
  timezone: number | null;
  is_banned: boolean;
  jwt: string;
}

interface Channel {
  id: string;
  link: string;
}

interface Chat {
  alignType: number;
  pekaMod: number;
  sound: boolean;
  soundVolume: number;
  smilesType: number;
  hide: number;
  quickBan: number;
  quickDelete: number;
  noBan: number;
  isDoSounds: boolean;
  isDoHide: boolean;
  isDoAnimate: boolean;
  isDoAlign: boolean;
  isShowPeka: boolean;
  customColors: {
    [key: string]: string;
  };
  customIcons: {
    [key: string]: string;
  };
}
