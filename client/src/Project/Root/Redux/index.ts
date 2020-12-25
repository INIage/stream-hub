import { compose, createStore } from 'redux';

import { reducer } from './reducer';

const enhancers: any[] = [];

if (typeof window !== 'undefined') {
  const devToolsExtension = (window as any)['__REDUX_DEVTOOLS_EXTENSION__'];

  if (typeof devToolsExtension === 'function') {
    enhancers.push(devToolsExtension());
  }
}

export const store = createStore(reducer, compose(...enhancers));
