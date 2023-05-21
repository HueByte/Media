export interface ApiResponse<T> {
  data: T | null;
  errors: string[];
  message: string;
}
