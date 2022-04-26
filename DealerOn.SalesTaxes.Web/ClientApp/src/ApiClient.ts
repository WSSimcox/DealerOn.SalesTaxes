export const productEndpoint = 'https://localhost:44301/api/v1/product/'
export const transactionEndpoint = 'https://localhost:44301/api/v1/transaction';

export function api<T, L>(url: string, input: L): Promise<T> {
    return fetch(url, { method: "POST", headers: { 'Content-Type': 'application/json'}, body: JSON.stringify(input)})
      .then(response => {
        if (!response.ok) {
          throw new Error(response.statusText)
        }
        return response.json() as Promise<T>;
      })      
  }