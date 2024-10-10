export type beach = {
  name: string
  description: string
  latitude: number
  longitude: number
  beach_id: number
}

export type surf = {
  name: any
  surf_beach_id: beach
  date: string
}
