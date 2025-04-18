export interface FileBody {
    body: string
}

export interface FileFromAzureResponse {
    fileName: string
    fileInBytes: ArrayBuffer
}

export interface Reason {
    message: string
}

export interface Result {
    isSuccess: boolean
    isFailed: boolean
    errors: Reason[]
}

export interface ResultWithValue<TValue> {
    isSuccess: boolean
    isFailed: boolean
    errors: Reason[]
    value: TValue
}

export interface UploadFileToBloStorageRequest {
    body: string
}
