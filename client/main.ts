type AsString<T> = T extends string ? T : never;
type Mirror<T extends Record<string, null>, N extends string | undefined> = N extends undefined
  ? { [K in keyof T]: K }
  : { [K in keyof T]: `@${N}/${AsString<K>}` };

const reducer1 = <TState, TAction>(state: TState, action: TAction) => {};
const reducer2 = <TState, TAction>(state: TState, action: TAction) => {};

const combined = <TState, TAction>(state: TState, action: TAction) => {
  const newState = reducer1(state, action);
  return reducer2(newState, action);
};
