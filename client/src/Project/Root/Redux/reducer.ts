import { combineReducers } from 'redux';

import { GoodGameReducer } from 'Foundation/GoodGame/reducer';

export const reducer = combineReducers({
  goodgame: GoodGameReducer,
});
