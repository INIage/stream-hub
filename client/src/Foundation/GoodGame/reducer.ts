import { combineReducers } from 'redux';

import { UserReducer } from './User/reducer';

export const GoodGameReducer = combineReducers({
  user: UserReducer,
});
